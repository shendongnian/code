c#
array1 = new int[TotalArray];
As for the loop. Here's the naive version, but if you need to scold the user for picking the same position twice, you'll need to do a lot more work. 
C#
int requestCount = TotalArray;
while (requestCount > 0)
{
    requestCount = requestCount - 1;
    Console.WriteLine("What position would you like to add your number to?: ");
    position = int.Parse(Console.ReadLine());
    if (position < TotalArray)
    {
        Console.WriteLine("What number would you like to add to position " + position);
        Number = int.Parse(Console.ReadLine());
        array1[position] = Number;
        Console.WriteLine("Testing: " + array1[position]);
        Console.ReadKey();
    }
    else
    {
        Console.WriteLine("Error! You entered your position higher than your total array!");
    }
}
