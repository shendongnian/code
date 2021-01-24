static void Main(string[] args) {
  askName();
}
static void askName() {
  Console.WriteLine("What's your name?");
  string name = Console.ReadLine();
  Console.WriteLine("Hello, " + name);
  Console.WriteLine("What's your age?");
  string age = Console.ReadLine();
  Console.WriteLine("Your name is " + name + " and you are " + age + " years old, Correct?");
  string val = Console.ReadLine();
  if (val == "yes") {
    Console.WriteLine("Data confirmed, thank you for your cooperation!");
  } else  if (val == "no") {
    askName();
  } else {
    //The issue with this line is that I want it to just ask if the data is correct again
    Console.WriteLine("That is not a valid response, try answering with a yes or no");
  }
}
