static void Main()
{
double numberOne = 0;
while (true)
{
    int choice = OutputMenu();
    if (choice == 9)
    {
        break;
    }
    Console.Clear();
    InputNumber(ref numberOne);
    if (choice == 1)
    {
        double Result = numberOne / 10000;
        Console.WriteLine(numberOne + " / " + 10000 + " = " + Result);
    }
    else if (choice == 2)
    {
        double Result = numberOne / 10000;
        Console.WriteLine(numberOne + " / " + 10000+ " = " + Result);
    }
    else if (choice == 3)
    {
            double Result = numberOne / 100;
            Console.WriteLine(numberOne + " / " + 100+ " = " + Result);
     }
    else if (choice == 4)
    {
        double Result = numberOne * 1.55e+9;
        Console.WriteLine(numberOne + " * " + 1.55e+9 + " = " + Result);
    }
     else if (choice == 5)
    {
        double Result = numberOne / 144;
        Console.WriteLine(numberOne + " / " + 144 + " = " + Result);
    }
}
}
private static int OutputMenu()
{
    Console.WriteLine("1. cm2 to m2");
    Console.WriteLine("2. m2 to ha");
    Console.WriteLine("3. ha to km²");
    Console.WriteLine("4. km2 to sq in");
    Console.WriteLine("5. in² to ft²");
    Console.WriteLine("9. Exit");
    int choice;
    while (true)
    {
        Console.WriteLine("Please enter the corresponding number to your option. Value has to fall between 1 and 5 or 9 ");
        if(int.TryParse(Console.ReadLine(), out choice) && ((choice > 0 && choice < 6) || choice == 9))) 
        {
           break;
         }
        else
        {
            Console.WriteLine("Please enter a valid number");
        }
    }
    return choice;
}
private static void InputNumber(ref double number1)
{
while (true)
    {
        Console.WriteLine("Please enter the number to be converted");
        if (double.TryParse(Console.ReadLine(), out number))
        {
                number1 = number;
                break;
        }
        else
        {
            Console.WriteLine("Please enter a valid number");
}
}
This should work.
