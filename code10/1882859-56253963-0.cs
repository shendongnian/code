    int[] array1 = new int[] { 1,2,3,4,5,6,7,8,9,10 };
            for (int i = 0; i < array1.Length; i+=2)
            {
                try
                {
                    Console.WriteLine(array1[i] + "  " + array1[i+1]);
                }
                catch (System.IndexOutOfRangeException)
                {
                   System.Console.WriteLine(array1[i]);
                    Console.ReadLine();
                }
            }
