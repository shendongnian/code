        public Subscriber()
        {
            InitializeComponent();
        }
        public Subscriber(Publisher publisher) : this()
        {
            publisher.OnPostUpdate += new PostUpdateHandler(publisher_OnPostUpdate);
        }
        private void publisher_OnPostUpdate(PostUpdateArgs args)
        {
            this.Form2_Load(null, null);
        }
        private void Subscriber_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            MessageBox.Show("http://stackoverflow.com");
        }
    }
When the user presses button1 on the publishing form, the subscribing form will execute the code associated with the delegate, resulting in a message box popping up with the message http://stackoverflow.com.
