     static void Main(string[] args)
            {
                days();
            }
            public static void days()
            {
                Console.Write("Please enter number : ");
                int a = Convert.ToInt32(Console.ReadLine());
    
                for (int i = 0; i < a; i++)
                {
                    string strdays;
                    switch (i)
                    {
                        case 0:
                            strdays = ". Todays date is : ";
                            break;
                        case 1:
                            strdays = ". Tommorrows date is : ";
                            break;
                        case 2:
                            strdays = ". Day after tommorrows date is : ";
                            break;                   
                        default:
                            strdays = ". " + (i-1) + "Days after tommorrows date is : ";
                            break;
                    }                    
                    Console.WriteLine((i+1)+ strdays + System.DateTime.Now.AddDays(i));                 
                }            
                Console.ReadLine();
            }
