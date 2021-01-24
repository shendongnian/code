            using System;
                
            int M = 5;//shift count
            int size; //size of array
            int[] myarray = new int[int.Parse(Console.ReadLine())];
            for (int i = 0; i < myarray.Length; i++)
            {
                myarray[i] = int.Parse(Console.ReadLine());
            }
            size = myarray.Length;
            if (size >= M)
            {
                Array.Reverse(myarray, 0, size);
                Array.Reverse(myarray, 0, M);
                Array.Reverse(myarray, M, size - M);
                for (int i = 0; i < myarray.Length; i++)
                {
                    Console.Write(myarray[i]+"\t");
                }
                Console.Read();
             }
           
