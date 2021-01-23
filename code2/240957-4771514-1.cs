    private void Button_Click(object sender, EventArgs e)
    {
       myLabel.Visible = false;
    }
    ///Somewhere in your form load or wherever you like
    private void form1_Load(object sender, EventArgs e)
    {
       myLabel.VisibleChanged += new EventHandler(this.Label_VisibleChanged);
    }
   
    private void Label_VisibleChanged(object sender, EventArgs e)
    {
       MessageBox.Show("Visible change event raised!!!");
    }
 
