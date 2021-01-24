        private static T ParseResult<T>(string queryResult) where T : new()
        {
            try
            {
                Result<T> res = JsonConvert.DeserializeObject<Result<T>>(queryResult);
                if (res.Success == 1)
                {
                    return res.Data;
                }
                return new T();
            }
            catch (Exception) {
                return new T();
            }
        }
