	using System;
						
	public class Program
	{	
		
		public class App {    	
	        public static AppShell MainPage; //Put this outside constructor
			static App () {
				MainPage = new AppShell();
			}
		}
	    public class AppShell   {
	        public void abc() {
	        	Console.WriteLine("AppShell::abc");
	        }
	    	public AppShell() { }
	 	}
			
		public static void Main()
		{
			App.MainPage.abc();
			Console.WriteLine("Hello World");
		}
	}
