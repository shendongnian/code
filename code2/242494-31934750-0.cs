            string Temp;
            int tempInt;
            bool result=false;
            while ( result == false )
                {
                Console.Write ("\n Enter Employee ID : ");
                Temp = Console.ReadLine ();
                result = int.TryParse (Temp, out tempInt);
                if ( result == false )
                    {
                    Console.Write ("\n Please Enter Numbers Only.");
                    }
                else
                    {
                    break;
                    }
                }
