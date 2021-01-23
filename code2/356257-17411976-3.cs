        private void button1_Click(object sender, EventArgs e)
        {
            var t = new System.Threading.Thread(new System.Threading.ThreadStart(x));
            t.Start();
        }
        private void x()
        {
            do
            {
                changeStatusMessageMethod(DateTime.Now.ToString());
                System.Threading.Thread.Sleep(1000);
            } while (true);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var t = new System.Threading.Thread(new System.Threading.ThreadStart(y));
            t.Start();
        }
        private void y()
        {
            do
            {
                incrementProgressBarMethod(1);
                System.Threading.Thread.Sleep(1000);
            } while (true);
        }
