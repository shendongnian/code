string nameQuestion = "What is your name?";
string name = string.Empty;
bool needName = true;
do {
   Console.WriteLine(nameQuestion);
   name = Console.ReadLine();
   Console.WriteLine($"Is {name} correct?");
   if (Console.ReadLine().ToLower().Equals("yes")) {
      needName = false;
   }
   else {
      nameQuestion = "Apologies, what is the correct name?";
   }
} while (needName);
Console.WriteLine("Great, lets move on.");
Console.ReadKey();
