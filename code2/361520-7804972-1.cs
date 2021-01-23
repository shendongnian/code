    public partial class Window1 : Window
    {
        private List<KeyValuePair<int, int>> list1;
        public int MyKey
        {
            get; set;
        }
        public Window1()
        {
            InitializeComponent();
            list1 = new List<KeyValuePair<int, int>>();
            var random = new Random();
            for (int i = 0; i < 50; i++)
            {
                list1.Add(new KeyValuePair<int, int>(i, random.Next(300)));
            }
            this.DataContext = list1;
        }
     }
