    namespace PurushLogics
    {
        class Purush_FirstNonRepeatingChar
        {
            public static void Main()
            {
                string inputString = "AABBCCdEEfGG";
                int i = 0;
                char[] a = inputString.ToCharArray();
                bool repeat = false;
                for (i = 0; i < a.Length; )
                {
    
                    for (int j = i + 1; j < a.Length; )
                    {
                        if (a[i] == a[j])
                        {
                            a = a.Where(w => w != a[i]).ToArray(); // Will return the array removing/deleting the character that is in a[i] location
                            repeat = true;
                            break;
                        }
                        else
                        {
    
                            repeat = false;
                        }
    
                        break;
                    }
    
                    if (repeat == false || a.Length == 1)
                    {
                        break;
                    }
                }
                Console.WriteLine(a[i]);
                Console.ReadKey();
            }
        }
    }
