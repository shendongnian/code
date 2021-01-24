            MemoryCache memoryCache = MemoryCache.Default;
            var test = memoryCache.Get("testKey")
            if (test != null) {
                return Ok(test) 
            } else {
                var data = GetData()
                     .ToList();
                memoryCache.Add("testKey", data, DateTimeOffset.UtcNow.AddDays(1));
                return Ok(data)
            }
	        
