    public partial class Window1 : Window
    {
        private Random _random;
        private List<Data> _dataItems;
    
        public Window1()
        {
            InitializeComponent();
            _dataItems = Init();
            _tvTest.ItemsSource = _dataItems;
            _random = new Random(5);
        }
    
        private List<Data> Init()
        {
            List<Data> dataItems = new List<Data>();
            for (int i = 1; i <= 10; i++)
            {
                Data d1 = new Data();
                d1.Name = "Data:" + i.ToString();
                for (int j = 1; j <= 4; j++)
                {
                    Data d2 = new Data();
                    d2.Name = "Data:" + i.ToString() + j.ToString();
                    d1.DataItems.Add(d2);
                }
                dataItems.Add(d1);
            }
            return dataItems;
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int index = _random.Next(0, 9);
            int subIndex = _random.Next(0, 3);
    
            if (subIndex == 0)
                _dataItems[index].Selected = true;
            else
                _dataItems[index].DataItems[subIndex - 1].Selected = true;
        }
    }
