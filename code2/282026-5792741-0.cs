    public Form1()
        {
            InitializeComponent();
            string query = "SELECT @Foo [Foo], '@Bar' [Bar], @Baz [Baz] ";
            Regex r = new Regex(@"[^']@([^\[,]+)");
            MatchCollection collection = r.Matches(query);
            string[] array = new string[collection.Count];
            for (int i = 0; i < collection.Count; i++)
            {
                array[i] = collection[i].Value.Trim();
                // If you want the string[] populated without the "@"
                // array[i] = collection[i].Groups[1].Value.Trim();
            }
        }
