    Public Class Test 
    {
        public string m_field1_Test{get;set;}
        public string m_field2_Test { get; set; }
        public Test()
        {
            m_field1_Test = "field1";
            m_field2_Test = "field2";
        }
        public MainWindow()
        {
            
            listTest = new List<Test>();
            for (int i = 0; i < 10; i++)
            {
                obj = new Test();
                listTest.Add(obj);
            }
            this.MyDatagrid.ItemsSource = ListTest;
            
            InitializeComponent();
           
        }
