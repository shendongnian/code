    protected override void OnInit(EventArgs e)  
    {   
        //create controls at every page load and assign the same ids to the controls
        //to preserve click events
        foreach (FileInfo f in dir.GetFiles("*.*"))  
        { 
            //create a new linkbutton
            LinkButton btn = new LinkButton();
            btn .ID = String.Format("lnk_{0}", pnlFilesBody.Controls.Count);
            btn.Click += new EventHandler(btn_Click);
            btn.Text = String.Format("Server Side Anchor {0}", pnlFilesBody.Controls.Count);
            //add the linkbutton to the files body panel
            pnlFilesBody.Controls.Add(btn);
        }
    }
    protected void btn_Click(object sender, EventArgs e)
    {
        //put your click event logic here
    }
