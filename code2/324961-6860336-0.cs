        delegate string CallFunctionDelegate(string arg1, string arg2);
 
        private void btnStart_Click(object sender, EventArgs e)
        {
            CallFunctionDelegate delegRunApps = new CallFunctionDelegate(DoSomeThingBig);
 
            AsyncCallback CallBackAfterAsynOperation = new AsyncCallback(AfterDoingSomethingBig);
 
            delegRunApps.BeginInvoke("", "", CallBackAfterAsynOperation, null);
        }
 
        private string DoSomeThingBig(string arg1, string arg2)
        {
            #region Implemetation of time consuming function
            //Implemetation of time consuming function
 
            for (int i = 0; i &lt; 5; i++)
            {
                Thread.Sleep(1000);
 
                if (btnStart.InvokeRequired)
                {
                    btnStart.Invoke((new MethodInvoker(delegate { btnStart.Text = i.ToString(); })));
                }
                else
                {
                    btnStart.Text = i.ToString();
                }
            } 
            #endregion
 
            return arg1.Replace("freetime", arg2);
        }
 
        private void AfterDoingSomethingBig(IAsyncResult result)
        {
            MessageBox.Show("Finaly Done!! ;) ");
 
            btnStart.Invoke((new MethodInvoker(delegate { btnStart.Text = "Start"; })));
        }
