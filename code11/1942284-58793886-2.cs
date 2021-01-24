    double[] array1 = new Double[10] { 0, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    double[] array2 = new Double[5] { 0, 1, 2, 3, 4 };
    double[] array3 = new double[10];
    int hold = 1;
    int counter = 0;
    for (int i = 0; i < array1.Length; i++)
    {
            if (i < array2.Length)
            {
                array3[i] = array1[i] * array2[i];
            }
            else
            {
                array3[i] = (array1[i] * hold);
            }
    }
    
    foreach (int j in array3)
        {
            Console.WriteLine(j);
        }
