            //==============go forwards===================
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
            //print resualts 
            Console.WriteLine(variable);
            //===================go backwards===============
            int variable2 = 10010;
            //convert it into a char array
            string value = variable2+"";
            //set the array length based on the size
            int[] reverse = new int[value.Length];
            //loop
            for (int i = 0; i < value.Length; ++i)
            {
                //grab the number from a char value and push it into the array
                reverse[i] = (int)Char.GetNumericValue(value[i]);
            }
            //print out
            for(int i = 0; i <reverse.Length;++i)
            {
                Console.WriteLine("[" + i + "] = " + reverse[i]);
            }
