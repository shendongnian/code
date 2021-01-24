                int last;
                int[] myarray = new int[int.Parse(Console.ReadLine())];
                for (int i = 0; i < myarray.Length; i++)
                {
                    myarray[i] = int.Parse(Console.ReadLine());
                }
    
                if (myarray.Length > 0)
                {
                    last = myarray[myarray.Length - 1];
                    for (int i = myarray.Length - 1; i > 0; i--)
                    {
                        myarray[i] = myarray[i - 1];
                    }
                    myarray[0] = last;
    
                    for (int i = 0; i < myarray.Length; i++)
                    {
                        Console.Write(myarray[i]);
                    }
    
                    Console.Read();
                }
