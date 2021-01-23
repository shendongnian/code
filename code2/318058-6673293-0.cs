    private void button1_Click(object sender, EventArgs e)
        {
            Form2 frmTest = new Form2();
            System.Threading.ThreadPool.QueueUserWorkItem(f =>
            {
                // easy to see the effect...
                System.Threading.Thread.Sleep(1000);
                Form2 me = f as Form2;
                this.BeginInvoke(new Action(() => {
                    me.Close();
                }));
            }, frmTest);
            frmTest.ShowDialog();
        }
