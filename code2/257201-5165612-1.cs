    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent(); 
    
            var loginInitial = new Subject<String>();
            var loginCheckList = new Subject<String>();
    
            var result1 = loginInitial.CombineLatest(loginCheckList, 
                    (x, y) => new Tuple<string, string>(x, y))
                .Where(latest => latest.Item1 == "Test" && latest.Item2 == "West")
                .Select(latest => string.Format("{0} - {1}", latest.Item1, latest.Item2));
    
            var result2 = from x in loginInitial
                            where x == "Test"
                            select x;
    
            var result3 = from x in loginCheckList
                            where x == "West"
                            select x;
    
            Observable.Merge(result1, result2, result3)
                .Subscribe(Console.WriteLine);
    
            var task1 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 10000000; i++)
                {
                    if (i == 9000000)
                        loginInitial.OnNext("9000000");
                    if (i == 9000001)
                        loginInitial.OnNext("Test");
                }
            });
    
            var task2 = Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 1000000; i++)
                {
                    if (i == 800000)
                        loginInitial.OnNext("800000");
                    if (i == 800001)
                        loginCheckList.OnNext("West");
                }
            });
    
            Task.WaitAll(task1, task2);
    
            Console.WriteLine("Done");
        }
    }
