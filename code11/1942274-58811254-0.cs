    public partial class Form1 : Form
    {
        Thread t;
        public delegate void DataRecieved();
        public event DataRecieved OnDataRecieved;
        public Form1()
        {
            InitializeComponent();
            t = new Thread(new ThreadStart(this.TriggerEvent));
            // Make sure that you are using STA
            // Otherwise you will get an error when creating WebBrowser
            // control in the Navigate method
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            OnDataRecieved += Navigate;
        }
        public void Navigate()
        {
            WebBrowser b = new WebBrowser();
            b.Navigate("www.google.com");
        }
        public void TriggerEvent()
        {
            
            Thread.Sleep(10000);
            OnDataRecieved();
        }
    }
