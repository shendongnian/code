    class Program
    		{
    			static void Main()
    			{
    				
    				//There was a syntax error in your code. It should be declare like this
    				SomeMethod(new List<string>(){("This give compilation Error")});
    
    				//Option 2 
    				List<string> MyMessages = new List<string>();
    				MyMessages.Add("This compiles fine");
    				SomeMethod(MyMessages);
    			}
    
    			static void SomeMethod(List<string> Messages)
    			{
    				foreach (string Message in Messages)
    					Console.WriteLine(Message);
    			}
    		}
 
