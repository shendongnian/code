            Random r = new Random();
            int[] arreglo = new int[100];
            for (int i=0; i<arreglo.Length;i++) {
                arreglo[i] = r.Next(1,1001);
            }
            for (int t = 0;t < arreglo.Length; t++)
            {
                if (arreglo[t] >= 1000)
                {
                    Console.Write("M"); arreglo[t] -= 1000;
                }
                if (arreglo[t] >=900)
                {
                    Console.Write("MC"); arreglo[t] -= 900;
                }
                if (arreglo[t] >= 500)
                {
                    Console.Write("D"); arreglo[t] -= 500;
                }
                if (arreglo[t] >= 400)
                {
                    Console.Write("CD"); arreglo[t] -= 400;
                }
                if (arreglo[t] >= 100) {
                    Console.Write("C"); arreglo[t] -= 100;
                }
                if (arreglo[t] >= 90)
                {
                    Console.Write("XC"); arreglo[t] -= 90;
                }
                if (arreglo[t] >= 50)
                {
                    Console.Write("L"); arreglo[t] -= 50;
                }
                if (arreglo[t] >= 40)
                {
                    Console.Write("XL"); arreglo[t] -= 40;
                }
                if (arreglo[t] >= 10)
                {
                    Console.Write("X"); arreglo[t] -= 10;
                }
                if (arreglo[t] >= 9)
                {
                    Console.Write("IX"); arreglo[t] -= 9;
                }
                if (arreglo[t] >= 5)
                {
                    Console.Write("V"); arreglo[t] -= 5;
                }
                if (arreglo[t] >= 4)
                {
                    Console.Write("IV"); arreglo[t] -= 4;
                }
                if (arreglo[t] >= 1)
                {
                    Console.Write("I"); arreglo[t] -= 1;
                }
                Console.WriteLine();
               
            }
            Console.ReadKey();    
