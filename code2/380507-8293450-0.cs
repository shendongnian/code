            // the input array
            int[] inputArray = new int[] { 10, 8, 8, 7, 6, 6, 6, 5 };
            // the number of parts you want
            int numberOfOutputParts = 3;
            // create the part structures
            List<Part> listOfParts = new List<Part>();
            for(int i =0; i < numberOfOutputParts; i++)
            {
                listOfParts.Add(new Part());
            }
            
            // iterate through each input value
            foreach (int value in inputArray)
            {
                // find the part with the lowest sum
                int? lowestSumFoundSoFar = null;
                Part lowestValuePartSoFar = null;
                foreach(Part partToCheck in listOfParts)
                {
                    if (lowestSumFoundSoFar == null || partToCheck.CurrentSum < lowestSumFoundSoFar)
                    {
                        lowestSumFoundSoFar = partToCheck.CurrentSum;
                        lowestValuePartSoFar = partToCheck;
                    }
                }
                // add the value to that Part
                lowestValuePartSoFar.AddValue(value);
            }
