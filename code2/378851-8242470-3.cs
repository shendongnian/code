    public void AddToList(string Message, int InputID)
    {
        if (this.InvokeRequired)
        {
            this.BeginInvoke(new dgAddToList(AddToList), new object[] { Message, InputID });
        }
        else
        {
            ListBox listBoxInstance = null;
    
            switch (InputID)
            {
                case 0:
                    listBoxInstance = this.listBox1;
                    break;
                case 1:
                    listBoxInstance = this.listBox2;
                    break;
                case 2:
                    listBoxInstance = this.listBox3;
                    break;
                case 3:
                    listBoxInstance = this.listBox4;
                    break;
            }
    
            if (listBoxInstance != null)
            {
                 listBoxInstance.Items.Insert(0, Message);
                 if (listBoxInstance.Items.Count > 100)
                 {
                    listBoxInstance.Items.RemoveAt(
                                      listBoxInstance.Items.Count - 1);
                 }
            }
        }
    }
