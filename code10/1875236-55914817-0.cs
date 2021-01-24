    int angka;
            Console.WriteLine("Masukkan Angka : ");
            angka = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i < angka; i++)
            {
                if(i==1)
                {
                    Console.Write(i);
                }
                else
                    Console.Write(","+i);
            }
            Console.WriteLine(" hop!");
            Console.ReadKey();
