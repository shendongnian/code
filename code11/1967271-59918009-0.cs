    Console.WriteLine("                  Please tender cash");
       decimal tend =decimal.Parse(Console.ReadLine());
        if (tend>total)
        {
       decimal change = tend - total;
       Console.WriteLine("         You gave " + " $"+tend + " Your change is " + "$"+change);
        }
        else
        {
            Console.WriteLine(" Please tender more cash");
        }
