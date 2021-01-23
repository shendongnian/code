    public class foo
    {
        public int e1 { get; set; }
        public int e2 { get; set; }
        public int e3 { get; set; }
        public int e4 { get; set; }
        public foo(int e1, int e2, int e3, int e4)
        {
            this.e1 = e1;
            this.e2 = e2;
            this.e3 = e3;
            this.e4 = e4;
        }
        public override string ToString()
        {
            return string.Format("e1 = {0}\te2 = {1}\te3 = {2}\te4 = {3}", e1, e2, e3, e4);
        }
    }
    public static void Main(string[] args)
    {
        List<foo> foosList = new List<foo>();
        Random r = new Random((int)DateTime.Now.Ticks);
        for (int i = 0; i < 10; i++)
            foosList.Add(new foo(r.Next(20), r.Next(20), r.Next(20), r.Next(5)));
        List<foo> result = foosList.OrderBy(e => e.e4).ThenBy(e => e.e3).ToList();
        result.ForEach(e => Console.WriteLine(e));
        Console.ReadKey();
    }
