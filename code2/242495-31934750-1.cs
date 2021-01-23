            string Temp;
            int tempInt,a;
            bool result=false;
            while ( result == false )
                {
                Console.Write ("\n Enter A Number : ");
                Temp = Console.ReadLine ();
                result = int.TryParse (Temp, out tempInt);
                if ( result == false )
                    {
                    Console.Write ("\n Please Enter Numbers Only.");
                    }
                else
                    {
                    a=tempInt;
                    break;
                    }
                }
