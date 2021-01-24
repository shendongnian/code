	/// <summary>
	/// Class that keeps track of cache keys and the expiration of said keys. 
	/// Uses a LIST to store the keys because it's faster than using SCAN on the entire Redis database.
	/// Expirations are stored as ticks.
	/// </summary>
    public static class KeyAndExpirationTracker
    {
        private const string ALL_KEYS = "ALL_KEYS";
        private const string EXPIRATION_SUFFIX = "|EXPIRATION";
        public static void StoreKeyAndExpiration(IDatabase db, string key, TimeSpan? timeToLive, ITransaction transaction)
        {
            string expiryKey = $"{key}{EXPIRATION_SUFFIX}";
			// although Redis will automatically replace an existing key, 
            // we still have to remove this in case this we went from having an expiration to not expiring
            db.KeyDelete(expiryKey);
            // add the item key to the list of keys
            transaction.SetAddAsync(key);
			// add the separate cache item for expiration (if necessary)
			if (timeToLive.HasValue)
			{
				DateTime expiry;
				try
				{
					expiry = DateTime.UtcNow.Add(timeToLive.Value);
					transaction.StringSetAsync(expiryKey, expiry.Ticks.ToString());
				}
				catch (ArgumentOutOfRangeException)
				{
					// no expiration then
				}
			}
        }
		public static void StoreKeyAndExpiration(IDatabase db, string key, DateTime? expiration, ITransaction transaction)
		{
            string expiryKey = $"{key}{EXPIRATION_SUFFIX}";
			// although Redis will automatically replace an existing key, we still have to remove this in case this we went from having an expiration to not expiring
            db.KeyDelete(expiryKey);
			// add the item key to the list of keys for this client type
			transaction.SetAddAsync(cacheKey, key);
			// add the separate cache item for expiration (if necessary)
			if (expiration.HasValue)
			{
				transaction.StringSetAsync(expiryKey, expiration.Value.Ticks.ToString());
			}
		}
        public static IEnumerable<string> GetKeys(IDatabase db)
        {
			RedisValue[] keys = db.SetMembers(ALL_KEYS));
			if (keys.Length == 0)
				return new string[0];
			List<string> expiredKeys = new List<string>(keys.Count());
			List<string> ret = new List<string>(keys.Count());
			// get expiration values using SORT with GET: https://redis.io/commands/sort
			RedisValue[] results = db.Sort(
				ALL_KEYS, 
				sortType: SortType.Alphabetic, 
				by: "notarealkey", // a (hopefully) non-existent key which causes the list to actually not be sorted
				get: new RedisValue[] { $"*{EXPIRATION_SUFFIX}", "#" } // # = "get the list item itself" which means the key in our case
			));
 
			// SORT results will be in the same order as the GET parameters: 
			// result[0] = expiration (= null if no matching expiration item found)
			// result[1] = key
			// (repeat)
			for (int i = 0; i < results.Length; i += 2)
			{
				string key = results[i + 1].Replace(EXPIRATION_SUFFIX, string.Empty);
				RedisValue expiryRedis = results[i];
				long ticks;
				if (long.TryParse(expiryRedis, out ticks))
				{
					DateTime expiry = new DateTime(ticks, DateTimeKind.Utc);
					if (expiry <= DateTime.UtcNow)
						expiredKeys.Add(key); // expired: add to list for removal
					else
						ret.Add(key);
				}
				else
					ret.Add(key);
			}
			// remove any expired keys from list
			if (expiredKeys.Count > 0)
			{
				IBatch batch = db.CreateBatch();
				batch.SetRemoveAsync(cacheKey, expiredKeys.ConvertAll(x => (RedisValue)x).ToArray());
				foreach (string expiredKey in expiredKeys)
				{
					batch.KeyDeleteAsync(expiredKey);
				}
				batch.Execute();
			}
			return ret;
       }
        public static void RemoveKeyAndExpiration(IDatabase db, string key, ITransaction transaction)
		{
            // remove the key from the list and its corresponding expiration value
			string expiryKey = $"{key}{EXPIRATION_SUFFIX}";
			transaction.SetRemoveAsync(ALL_KEYS, key);
			transaction.KeyDeleteAsync(expiryKey);
		}
    }
