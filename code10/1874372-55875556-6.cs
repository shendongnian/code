    private static void ShowValues()
    {
        Console.WriteLine($"Current values: A = {A}, B = {B}, C = {C}.");
    }
    private static int GetIntFromUser(string prompt)
    {
        int input;
        do
        {
            Console.Write(prompt);
        } while (!int.TryParse(Console.ReadLine(), out input));
        return input;
    }
    private static void Main(string[] args)
    {
        while (true)
        {
            ShowValues();
            ProcessInput(GetIntFromUser("Input a value: "));
        }
    }
