    class Program
    {
        
        static void Main(string[] args)
        {
            IEnumerable<MyData> list = ReadFileAsEnumerable("testywesty.txt");
            Debug.WriteLine(MyData.ToHeading());
            foreach (var item in list)
            {
                Debug.WriteLine(item);
            }            
            // date        x    a    b   
            // 1/1/2018       0   29   10
            // 1/2/2018       0   16    1
            // 1/3/2018       0   32    1
            // 1/4/2018       0   34   15
            // 1/5/2018       0   19    2
            // 1/6/2018       0   21    2
            // 1/29/2018   0.32   52   38
            // 1/30/2018   0.06   44   21
        }
        public static IEnumerable<MyData> ReadFileAsEnumerable(string file)
        {
            var fs = File.OpenText(file);
            while (!fs.EndOfStream)
            {
                yield return MyData.Parse(fs.ReadLine());
            }
            fs.Close();
        }
    }
    /// <summary>
    /// Stores a row of my data
    /// </summary>
    /// <remarks>
    /// Mutable structures are evil. Make all properties read-only.
    /// </remarks>
    public struct MyData
    {
        public MyData(DateTime date, float number, int a, int b)
        {
            this.Date = date;
            this.Number= number;
            this.A=a;
            this.B=b;
        }
        public DateTime Date { get; }
        public float Number { get; }
        public int A { get; }
        public int B { get; }
        public static MyData Parse(string line)
        {
            // split line into string parts at every ';'
            var parts = line.Split(';');
            // if 1st part is date store in 1st column
            if (DateTime.TryParse(parts[0], out DateTime date)) { }
            // if 2nd part is flaot store in 2nd column
            if (float.TryParse(parts[1], out float number)) { }
            // if 3rd part is integer store in 3rd column
            if (int.TryParse(parts[2], out int a)) { }
            // if 4rd part is integer store in 4rd column
            if (int.TryParse(parts[3], out int b)) { }
            return new MyData(
                date,
                number,
                a,
                b);
        }
        public static string ToHeading()
        {
            return $"{"date",-11} {"x",-4} {"a",-4} {"b",-4}";
        }
        public override string ToString()
        {
            return $"{Date.ToShortDateString(),-11} {Number,4} {A,4} {B,4}";
        }
    }
