public static void  Main(string[] args)
       {
           var post = new Post();
           string description = "";      // variable declaration
            Console.WriteLine("Wanna share a post? If so please pres 'y' otherwise any key to cancel");
            while(true)
            {
                var input = Console.ReadLine();
                if (input == "y")
                {
                    Console.Clear();
                    post.SetTitle();
                    string title = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(title))
                    {
                        post.SetTitle();
                    }
                    else
                    {
                       post.SetDescription();
                       description = Console.ReadLine(); // variable assignment
                    }
                    Console.WriteLine( title + description );
                }
                else 
                {
                    Console.WriteLine("GoodBye");
                    break;
                }
            }
       }
    }
