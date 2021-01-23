                //Read the size of the array, you can get it from .Count() if you wish
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] a = new int[n][];
            //Reading all the values and preparing the array (a)
            for (int a_i = 0; a_i < n; a_i++)
            {
                string[] a_temp = Console.ReadLine().Split(' ');
                a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
            }
            //performing the operation (google what diagonal matrix means)
            int PrimarySum = 0, SecondarySum = 0;
            for (int i = 0; i < n; i++)
            {
                //The If condition is to skip the odd numbers
                if (a[i][i] % 2 == 0) { PrimarySum += a[i][i]; }
                //For the reverse order
                int lastelement = a[i].Count() - 1 - i;
                if (a[i][lastelement] % 2 == 0) { SecondarySum += a[i][lastelement]; }
            }
            //Get the absolute value
            Console.WriteLine(Math.Abs(PrimarySum - SecondarySum).ToString());
            Console.ReadKey();
