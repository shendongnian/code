await ClearKey($"ordersList:{apiAccount.Id}");
       public async Task ClearKey(string key) {
            try
            {
                await _redisDb.KeyDeleteAsync(key);
            }
            catch (Exception ex)
            {
                // log exception
            }
      }
