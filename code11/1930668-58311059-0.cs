while (true)
{
    bool valid = int.TryParse(Console.ReadLine(), out myNum);
    if(valid)
        break;
    Console.WriteLine("Input invalid. Please try again");
}
