c#
using System;
					
public class Program
{
	public static void Main()
	{
		var a= new KeyValueDto<int>(){
		    Key = 1,
			Value = "ali"
		};
		
		var b = new KeyValueDto<string>{
			Key = "1",
			Value = "ali1"
		};
		
	}
	
	public class KeyValueDto<T>
    {
        public T Key { get; set; }
        public object Value { get; set; }
    }
	
}
