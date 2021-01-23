    private void AddLinkLabels()
    {
        // If synchronization is needed, i.e. when this method is called on a non-UI thread, invoke the method synchronized and return immediately.
        if(InvokeRequired)
        {
            Invoke(new MethodInvoker(AddLinkLabels));
            return;
        }
    
        for (int i = 0; i < 10; i++)
        {
            linkLabel = new System.Windows.Forms.LinkLabel();
            linkLabel.Name = i.ToString();
            linkLabel.Text = i.ToString();
            linkLabel.LinkClicked += new  System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel_LinkClicked);
            this.Controls.Add(linkLabel);
            linkLabel.Top = top;
            top += 30;
        }
    }
