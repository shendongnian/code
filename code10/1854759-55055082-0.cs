    int[] array1 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
    int[] array2 = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int tmp = array1[0];
            int index = Array.IndexOf(array2, tmp);
            int n = array1.Length;
            
            for (int i = 1; i < n; i++)
            {
                if (index + i < array1.Length)
                {
                    if (array1[i] != array2[index+i])
                    {
                        Console.WriteLine("Arrays are not equal");
                        break;
                    }
                }
                else
                {
                    if (array1[i] != array2[index + i - n])
                    {
                        Console.WriteLine("Arrays are not equal");
                        break;
                    }
                }
            }
