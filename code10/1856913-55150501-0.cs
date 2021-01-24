    class Program
	{	
		static void displayMainMenu()
		{
			string title = "Old Yeller Pet Store";
			Console.WriteLine("\n\n");
			Console.WriteLine(String.Format("{0," + ((Console.WindowWidth /2) + (title.Length / 2 )) + "}", title));
			Console.WriteLine("\n");
			
			title = "Main Menu";
			Console.WriteLine("\n\n");
			Console.WriteLine(String.Format("{0," + ((Console.WindowWidth /2) + (title.Length / 2 )) + "}", title));
			Console.WriteLine("\n");
			
			string line = "1.    Buy a Pet";
			Console.WriteLine(line.PadLeft(line.Length+1 + 50));
			
			string line2 = "2.    Buy Food";
			Console.WriteLine(line2.PadLeft(line2.Length+1 + 50));
			
			string line3 = "3.    File OPs";
			Console.WriteLine(line3.PadLeft(line3.Length+1 + 50));
			
			string line4 = "4.    Manager";
			Console.WriteLine(line4.PadLeft(line4.Length+1 + 50));
			
			string line5 = "5.    Quit";
			Console.WriteLine(line5.PadLeft(line5.Length+1 + 50));
			
			
		}
		
		static void getChoice()
		{
			string option;
			int choice;
			Console.WriteLine("Please input which number option you choose to use");
			option = Console.ReadLine();
			choice = Convert.ToInt32(option);
			if (choice == 1)
			{
				Console.Write("Lipsum");
				//code to open Buy a Pet menu
			}
			
					
			
		}
		
				
		public static void Main(string[] args)
		{
			displayMainMenu ();
			getChoice();
			
				
			
			Console.ReadKey();
				
		}
	}
