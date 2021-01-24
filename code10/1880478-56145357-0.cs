	public class Result
	{
		private Result(){}
		
		public bool Successful {get;private set;} = false;
		
		public string Key {get; private set;} = string.Empty;
		
		public string Value {get; private set;} = string.Empty;
		
		public static Successful(string key, string value)
		{
			return new Result
			{
				Successful = true,
				Key = key,
				Value = value
			};
		}
		
		public static Failed()
		{
			return new Result();
		}
	}
    public Result GetKeyValue(string line){
         return Result.Failed();
    }
