    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
    
            var req = WebRequest.Create("http://www.google.com");
    
            Observable
                .FromAsyncPattern<WebResponse>(req.BeginGetResponse, req.EndGetResponse)()
                .ObserveOn(this)
                .Subscribe(r =>
                                {
                                    using (var s = r.GetResponseStream())
                                    using (var reader = new StreamReader(s))
                                    {
                                        textBox1.Text = reader.ReadToEnd();
                                    }
                                },
                            ex =>
                                {
                                    textBox1.Text = ex.Message;
                                });
        }
    }
