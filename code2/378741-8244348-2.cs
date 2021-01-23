        public Form1()
        {
            InitializeComponent();
            webBrowser1.ObjectForScripting = new MyScript();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = @"
                <html>
                <head>
                    
                </head>
                    <body><div id='results'>default here?</div>
                    <script type='text/javascript'>
                        //your javascript here                        
                        window.external.CallServerSideCode('myResults from callback');;
                        
                    </script></body>
                </html>";
        }
        [ComVisible(true)]
        public class MyScript
        {
            public void CallServerSideCode(string myResponse)
            {
                //do stuff with myResponse
            }
        }
