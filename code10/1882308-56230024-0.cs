    var i = 0;
    var j = 0;
    var k = 0;
    var num = 5;
    for (i = 1; i <= num; i++)
    {
        for (j = 1; j < num - i + 1; j++)
        {
            Console.Write(" ");
        }
        for (k = 1; k <= i; k++)
        {
            Console.Write("*");
            Console.Write(" ");
        }
        Console.WriteLine();
    }
    for (i = (num-1); i > 0; i--)
    {
        for (j = 1; j < num - i + 1; j++)
        {
            Console.Write(" ");
        }
        for (k = 1; k <= i; k++)
        {
            Console.Write("*");
            Console.Write(" ");
        }
        Console.WriteLine();
    }
}
