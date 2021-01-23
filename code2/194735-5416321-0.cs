    class Program
    {
        void StringInput(string str)
        {
            string[] st1 = str.Split(' ');
           
            if (st1 != null)
            {
                string a = str.Substring(0, 1);
                string b=str.Substring(str.Length-1,1);
                
                 if(
                    a=="^" && b=="^" 
                    || a=="{" && b=="}" 
                    || a=="[" && b=="]"
                    ||a=="<" && b==">" 
                    ||a=="(" && b==")"
                    )
                {
                    Console.Write("ok Formate correct");
                }
                else
                {
                    Console.Write("Sorry incorrect formate...");
                }
            }
        }
        static void Main(string[] args)
        {
            ubaid: ;
            Program one = new Program();
            Console.Write("For exit Press N ");
            Console.Write("\n");
            Console.Write("Enter your value...=");
            string ub = Console.ReadLine();
           
            if (ub == "Y" || ub=="y" || ub=="N" || ub=="n" )
            {
                Console.Write("Are your want to Exit Y/N: ");
                string ui = Console.ReadLine();
                if (ui == "Y" || ui=="y")
                {
                    return;
                }
                else
                {
                    goto ubaid;
                }
                
            }
            one.StringInput(ub);           
            Console.ReadLine();
            goto ubaid;
        }
    }
