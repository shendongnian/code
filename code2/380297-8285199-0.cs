    using System;
    
    namespace Ticket
    {
        class blah
        {
            public void abc()
            {
    
                int numberOfTickets;
                int numberOfAvailableTickets=10;
                int cost = 100;
                int pay;
                Console.WriteLine("how many tickets do you need");
                numberOfTickets = Convert.ToInt32(Console.ReadLine());
    
                try
                {
                       
                if( numberOfTickets>numberOfAvailableTickets)
                    throw new Exception ("Not enough Tickets available!");
    
                    
                        pay = 100 * numberOfTickets;
                        Console.WriteLine("Pay please");
                        Console.WriteLine(pay);
    
                }
                catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
            }
        }
    
    }
        class Theater
        {
            static void Main(string[] args)
            {
                blah hi = new blah();
                hi.abc();
                Console.ReadLine();
    
            }
        }
    }
