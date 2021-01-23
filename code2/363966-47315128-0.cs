    public void AddData(string data)
        {
            if (this.ResponseData.InvokeRequired)
                BeginInvoke(new AddDataDelegate(AddData), new object[] { data });
            else
            {
                this.ResponseData.Items.Insert(0, data);
                DataDistro();
   
            }
                            
        }
