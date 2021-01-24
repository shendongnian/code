    class Program
    {
        private enum Values
        {
            LOW,
            MEDIUM,
            HIGH
        }
        static void Main(string[] args)
        {
            // Sample data
            Values[] settings = new Values[10];
            settings[0] = Values.LOW;
            settings[1] = Values.HIGH;
            settings[2] = Values.MEDIUM;
            settings[3] = Values.LOW;
            settings[4] = Values.LOW;
            settings[5] = Values.LOW;
            settings[6] = Values.LOW;
            settings[7] = Values.LOW;
            settings[8] = Values.MEDIUM;
            settings[9] = Values.MEDIUM;
            // Get Values of the enum type
            // This list is sorted ascending by value but may contain duplicates
            Array enumValues = Enum.GetValues(typeof(Values));
            // Number of results found so far
            int numberFound = 0;
            // The enum value we used during the last outer loop, so
            // we skip duplicate enum values
            int lastValue = -1;
            // For each enum value starting with the highest to the lowest
            for (int i= enumValues.Length -1; i >= 0; i--)
            {
                // Get this enum value
                int enumValue = (int)enumValues.GetValue(i);
                // Check whether we had the same value in the previous loop
                // If yes, skip it.
                if(enumValue == lastValue)
                {
                    continue;
                }
                lastValue = enumValue;
                // For each entry in the list where we are searching
                for(int j=0; j< settings.Length; j++)
                {
                    // Check to see whether it is the currently searched value
                    if (enumValue == (int)settings[j])
                    {
                        // if yes, then output it.
                        Console.WriteLine(j);
                        numberFound++;
                        // Stop after 3 found entries
                        if (numberFound == 3)
                        {
                            goto finished;
                        }
                    }
                }
            }
            finished: 
            Console.ReadLine();
        }
    }
