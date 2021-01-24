            int avrg = 0; //Add a variable to store the averages
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    avrg = 0;
                    for (int k = 0; k < 3; k++)
                    {
                        Console.WriteLine("a[{0},{1},{2}] : {3}", i, j, k, array3D[i, j, k]);
                        avrg += array3D[i, j, k]; //sum the values
                    }
                    avrg = avrg / array3D.GetLength(2); //calculate the average
                    Console.WriteLine("avrg: {0}", avrg); // print the avrg value
                }
            }
        }
