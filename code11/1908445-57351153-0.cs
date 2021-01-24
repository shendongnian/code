namespace CustomObjectFromData
{
    // Represents an entry from your list of data
    class TestData
    {
        /* Replace 'public' with 'private' if you only want the value to be set at initialization. 
         * 'TEST_VALUE' has been replaced with 'seriesValue'. */
        public int id, year, value, seriesValue;
        public TestData(int id, int year, int value, int seriesValue)
        {
            this.id = id;
            this.year = year;
            this.value = value;
            this.seriesValue = seriesValue;
        }
    }
    // Formats the data as you requested using 'ShowData'
    class DisplayList
    {
        // Edit these to edit the amount of spaces in a margin
        const string firstTab = " ";    // Space between edge and first index
        const string secondTab = "  ";  // Space between edge and TEST_VALUE
        const string thirdTab = "   ";  // Space between edge and data
        private List<TestData> values;
        // Initialize the list for the instance
        public DisplayList()
        {
            values = new List<TestData>();
        }
        // Adds 'toAdd' to the list of TestData entries.
        public void AddValue(TestData toAdd)
        {
            values.Add(toAdd);
        }
        public void AddFromList(List<TestData> list)
        {
            foreach (TestData element in list)
            {
                values.Add(element);
            }
        }
        // Format and show data as requested.
        public void ShowData()
        {
            // Default message if 'values' is empty.
            if (values.Count == 0)
            {
                Console.WriteLine("Data\n --> [Empty]");
                return;
            }
            // Find the amount of unique 'seriesValue' in 'values'
            List<int> uniqueSeriesValues = new List<int>();
            foreach (TestData element in values)
            {
                if (!uniqueSeriesValues.Contains(element.seriesValue))
                {
                    uniqueSeriesValues.Add(element.seriesValue);
                }
            }
            // Set up another list so that the values are grouped based on ID in ascending order.
            List<int> uniqueIdValues = new List<int>();
            foreach (TestData element in values)
            {
                if(!uniqueIdValues.Contains(element.id))
                {
                    uniqueIdValues.Add(element.id);
                }
            }
            uniqueIdValues.Sort();
            // Final variable setup before display
            int uniqueSeriesValuesCount = uniqueSeriesValues.Count;
            // Display data
            Console.WriteLine("Data");
            for (int i = 0; i < uniqueSeriesValuesCount; i++)
            {
                int currentIdValue = uniqueIdValues[i];
                Console.WriteLine($"{firstTab}--> [{i}]");
                Console.WriteLine($"{secondTab}--> Series Value: {uniqueSeriesValues[i]}");
                Console.WriteLine($"{secondTab}--> Data from ID '{currentIdValue}':");
                foreach (TestData element in values)
                {
                    int innerCounter = 0;
                    if (element.id == currentIdValue)
                    {
                        Console.WriteLine($"{thirdTab}[{innerCounter}] {element.id, -5} {element.year, -7} {element.value, -7} {element.seriesValue}");
                        innerCounter++;
                    }
                }
            }
        }
    }
}
A script that implements this namespace: 
    class Execute
    {
        static void Main(string[] args)
        {
            List<TestData> fromProcedure = new List<TestData>();
            fromProcedure.Add(new TestData(1, 2019, 78, 3));
            fromProcedure.Add(new TestData(1, 2020, 12, 3));
            fromProcedure.Add(new TestData(1, 2021, 56, 3));
            fromProcedure.Add(new TestData(2, 2019, 23, 2));
            fromProcedure.Add(new TestData(2, 2020, 89, 2));
            fromProcedure.Add(new TestData(2, 2021, 34, 2));
            DisplayList display = new DisplayList();
            display.AddFromList(fromProcedure);
            display.ShowData();
        }
    }
Further Instructions:
 1. Obtain data from the procedure, and place it into a list of 'TestData' objects. The objects have the following format: **id**, **year**, **value**, **test_value**. In the implementation, I replaced the name 'TEST_VALUE' with series value.
 2. Create an instance of the 'DisplayList' class
 3. Use 'AddFromList' to create the data from the list.
 4. Call 'ShowData' to print the data to the screen.
Hopefully this is compatible with the already existing code you wrote.
