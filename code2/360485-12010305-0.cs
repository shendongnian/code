    class LaserArray
    {
        private int minimum;
        private int maximum;
        private double average;
        private bool finishedReading;
        private StreamReader sr;
        public int Minimum
        { get { return finishedReading ? minimum : -1; } }
        public int Maximum
        { get { return finishedReading ? maximum : -1; } }
        public double Average
        { get { return finishedReading ? average : -1; } }
        public bool FinishedReading
        { get { return finishedReading; } }
        public bool StreamInitialized
        { get { return sr != null; } }
        private int[][] arr;
          
        public LaserArray()
        {
            arr = new int[310][];
            finishedReading = false;
        }
        public bool InitStream(Stream s)
        {
            try
            {
                sr = new StreamReader(s);
                /*alternatively, as I have no clue about your Stream:
                 * sr = new StreamReader(s, bool detectEncodingFromByteOrderMarks)
                 * sr = new StreamReader(s, Encoding encoding)
                 * sr = new StreamReader(s, Encoding encoding, bool detectEncodingFromByteOrderMarks)
                 * sr = new StreamReader(s, Encoding encoding, bool detectEncodingFromByteOrderMarks, int buffersize)
                 * */
            }
            catch(Exception)
            {
                Console.WriteLine("Invalid Stream object.");
                sr = null;
                return false;
            }
            return true;
        }
        public void ReadInData()
        {
            if (sr == null)
            {
                Console.WriteLine("Initialize a Stream with UseStream first.");
                return;
            }
            if (finishedReading)
            {
                Console.WriteLine("The stream is already read.");
                return;
            }
            minimum = int.MaxValue; maximum = 0;
            int currentTotal = 0;
            for (int rowCounter = 0; rowCounter < 310; rowCounter++)
            {
                arr[rowCounter] = new int[24];
                int indexCounter = 0;
                for (int i = 0; i < 6; i++)
                {                                   // 0#,22008,21930,00000, n / a, n / a !
                    char[] buffer = new char[28];   //123456789012345678901234  5  67  8 makes 28 characters?
                    try
                    {
                        sr.ReadBlock(buffer, 0, 2 + 5 + 1); 
                    }
                    catch (IOException e)
                    {
                        //some error occurred
                        Console.WriteLine("IOException: " + e.Message);
                    }
                    string input = new String(buffer);
                    arr[rowCounter][indexCounter] = int.Parse(input.Substring(2, 2));
                    indexCounter++;
                    int currentNumber;
                    currentNumber = int.Parse(input.Substring(6, 5));
                    arr[rowCounter][indexCounter] = currentNumber;
                    currentTotal += currentNumber;
                    if (currentNumber > maximum)
                        maximum = currentNumber;
                    if (currentNumber < minimum)
                        maximum = currentNumber;
                    indexCounter++;
                    
                    currentNumber = int.Parse(input.Substring(12, 5));
                    arr[rowCounter][indexCounter] = currentNumber;
                    currentTotal += currentNumber;
                    if (currentNumber > maximum)
                        maximum = currentNumber;
                    if (currentNumber < minimum)
                        maximum = currentNumber;
                    indexCounter++;
                    
                    currentNumber = int.Parse(input.Substring(18, 5));
                    arr[rowCounter][indexCounter] = currentNumber;
                    currentTotal += currentNumber;
                    if (currentNumber > maximum)
                        maximum = currentNumber;
                    if (currentNumber < minimum)
                        maximum = currentNumber;
                    indexCounter++;
                }
            }
            average = currentTotal / (double) 310;
            //succesfully read in 310 lines of data
            finishedReading = true;
        }
        public int GetMax(int topRow, int leftColumn, int bottomRow, int rightColumn)
        {
            if (!finishedReading)
            {
                Console.WriteLine("Use ReadInData first.");
                return -1;
            }
            int max = 0;
            for (int i = topRow; i <= bottomRow; i++)
                for (int j = leftColumn; j <= rightColumn; j++)
                {
                    if (j == 0 || j == 4 || j == 8 || j == 12 || j == 16 || j == 20 || j == 24)
                        continue;
                    if (arr[i][j] > max)
                        max = arr[i][j];
                }
            return max;
        }
        public int GetMin(int topRow, int leftColumn, int bottomRow, int rightColumn)
        {
            if (!finishedReading)
            {
                Console.WriteLine("Use ReadInData first.");
                return -1;
            }
            int min = 99999;
            for (int i = topRow; i <= bottomRow; i++)
                for (int j = leftColumn; j <= rightColumn; j++)
                {
                    if (j == 0 || j == 4 || j == 8 || j == 12 || j == 16 || j == 20 || j == 24)
                        continue;
                    if (arr[i][j] < min)
                        min = arr[i][j];
                }
            return min;
        }
        public double GetAverage(int topRow, int leftColumn, int bottomRow, int rightColumn)
        {
            if (!finishedReading)
            {
                Console.WriteLine("Use ReadInData first.");
                return -1;
            }
            int total = 0;
            int counter = 0;
            for (int i = topRow; i <= bottomRow; i++)
                for (int j = leftColumn; j <= rightColumn; j++)
                {
                    if (j == 0 || j == 4 || j == 8 || j == 12 || j == 16 || j == 20 || j == 24)
                        continue;
                    counter++;
                    total += arr[i][j];
                }
            return total / (double) 310;
        }
    }
