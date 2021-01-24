    static void Main(string[] args)
    {
    	bool finished;
    	
    	do
    	{
    		finished = true;
    		Console.WriteLine("What's your name?");
    		string name = Console.ReadLine();
    		Console.WriteLine("Hello, " + name);
    		Console.WriteLine("What's your age?");
    		string age = Console.ReadLine();
    		Console.WriteLine("Your name is " + name + " and you are " + age + " years old, Correct?");
    		string val = Console.ReadLine();
			while(val != "yes" && val != "no") {
    			Console.WriteLine("That is not a valid response, try answering with a yes or no");
				val = Console.ReadLine();
			}
			if (val == "yes") {
    			Console.WriteLine("Data confirmed, thank you for your cooperation!");
    		}
    		else if (val == "no") {
    			Console.WriteLine("Incorrect data provided, please try again");
    			finished = false;
    		}
    	} while(!finished);
    }
