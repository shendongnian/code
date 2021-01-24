    using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("localhost:6379,allowAdmin=true"))
            {
                IDatabase db = redis.GetDatabase();
                var keys = redis.GetServer("localhost", 6379).Keys();
                string[] keysArr = keys.Select(key => (string)key).ToArray();
                foreach (string key in keysArr)
                {
                    Console.WriteLine(db.StringGet(key));
                }
            }
