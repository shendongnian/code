    void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                object o = e.Argument;
                object[] args = (object[])o;
                string fileName = (string)args[0];
                ....
                object[] result = ....
                e.Result = result;
            }
