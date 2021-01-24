csharp
public void UserInput(string input) {
    Console.WriteLine($"You choose {input}");
}
However, if you only wish to handle certain cases (in your case, only 1 and 2), then you can use a switch statement:
csharp
public void UserInput(string input) {
    switch(input) {
        case "1":
        case "2":
            Console.WriteLine($"You choose {input}"); // will only write 1 or 2
            break; // necessary to prevent fall-through
        default:
            Console.WriteLine("Invalid Response");
            
