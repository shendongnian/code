            int[] array = { 1, 0, 0, 1, 0 };
            int variable = 0;
            for (int i = 0; i < array.Length; ++i)
            {
                //first element
                if (i == 0)
                    variable = array[i];
                else
                {
                    variable *= 10;
                    variable += array[i];
                }
            }
            Console.WriteLine(variable);
