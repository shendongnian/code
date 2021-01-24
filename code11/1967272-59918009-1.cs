                decimal total = 15.75m;
    
                while (true)
                {
                    Console.WriteLine("                  Please tender cash");
                    decimal tend = decimal.Parse(Console.ReadLine());
    
                    if (tend == total)
                    {
                        Console.WriteLine("         You gave " + " $" + tend + "the exact amount.");
                        Console.ReadLine();
                        break;
                    }
    
                    if (tend > total)
                    {
                        decimal change = tend - total;
                        Console.WriteLine("         You gave " + " $" + tend + " Your change is " + "$" + change);
                        Console.ReadLine();
                        break;
                    }
    
                    total -= tend;
                    Console.WriteLine("         You gave " + " $" + tend);
                    Console.WriteLine("         You still own " + " $" + total);
                }
