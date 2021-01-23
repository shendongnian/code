            // Create the array.
            Array myArray = Array.CreateInstance(typeof(double), new int[1] { 12 }, new int[1] { 1 });
            // Fill the array with random values.
            Random rand = new Random();
            for (int index = myArray.GetLowerBound(0); index <= myArray.GetUpperBound(0); index++)
            {
                myArray.SetValue(rand.NextDouble(), index);
            }
            // Display the values.
            for (int index = myArray.GetLowerBound(0); index <= myArray.GetUpperBound(0); index++)
            {
                Console.WriteLine("myArray[{0}] = {1}", index, myArray.GetValue(index));
            }
