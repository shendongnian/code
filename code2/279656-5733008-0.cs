            Array myArray = Array.CreateInstance(typeof(double), new int[1] { 12 }, new int[1] { 1 });
            Random rand = new Random();
            for (int index = myArray.GetLowerBound(0); index <= myArray.GetUpperBound(0); index++)
            {
                myArray.SetValue(rand.NextDouble(), index);
            }
            for (int index = myArray.GetLowerBound(0); index <= myArray.GetUpperBound(0); index++)
            {
                Console.WriteLine("myArray[{0}] = {1}", index, myArray.GetValue(index));
            }
