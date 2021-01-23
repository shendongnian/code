    continueflag = 0;
    while (continueflag == 0)
    {
        sales_figures[CustPos] = Double.Parse(Console.ReadLine());
        Console.WriteLine("");
        
        if (sales_figures[CustPos] >= MIN_SALES_FIGURE) {
            Console.WriteLine("entry invalid");
            Console.WriteLine("enter another value");
        } else continueflag = 1;
    }
