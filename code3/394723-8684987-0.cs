        System.Threading.Thread t;
        private void Form1_Load(object sender, EventArgs e)
        {
            //create and start a new thread in the load event.
            //passing it a method to be run on the new thread.
            t = new System.Threading.Thread(DoThisAllTheTime);
            t.Start();
        }
        public void DoThisAllTheTime()
        {
            while (true)
            {
                //you need to use Invoke because the new thread can't access the UI elements directly
                MethodInvoker mi = delegate() { this.Text = DateTime.Now.ToString(); };
                this.Invoke(mi);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //stop the thread.
            t.Suspend();
        } 
