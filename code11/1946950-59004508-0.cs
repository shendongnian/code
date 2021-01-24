    class Program
    {
        
        static void Main(string[] args)
        {
            object[,] array = ReadFileAsArray("testywesty.txt");            
        }
        static object[,] ReadFileAsArray(string file)
        {
            // how long is the file?
            // read it twice, once to count the rows 
            // and a second time to read each row in
            int rows = 0;
            
            var fs = File.OpenText(file);
            while (!fs.EndOfStream)
            {
                fs.ReadLine();
                rows++;
            }
            fs.Close();
            var array = new object[rows, 4];
            fs = File.OpenText(file);
            int row = 0;
            while (!fs.EndOfStream)
            {
                // read line
                var line = fs.ReadLine();
                // split line into string parts at every ';'
                var parts = line.Split(';');
                // if 1st part is date store in 1st column
                if (DateTime.TryParse(parts[0], out DateTime date))
                {
                    array[row, 0] = date;
                }
                // if 2nd part is flaot store in 2nd column
                if (float.TryParse(parts[1], out float x))
                {
                    array[row, 1] = x;
                }
                // if 3rd part is integer store in 3rd column
                if (int.TryParse(parts[2], out int a))
                {
                    array[row, 2] = a;
                }
                // if 4rd part is integer store in 4rd column
                if (int.TryParse(parts[3], out int b))
                {
                    array[row, 3] = b;
                }
                row++;
            }
            fs.Close();
            return array;
        }
    }
