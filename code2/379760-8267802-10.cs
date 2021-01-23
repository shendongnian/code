      public Form1()
    {
      InitializeComponent();
      pictureBox2.Visible = false;
    }
    private void Form1_Load(object sender, EventArgs e) 
    { 
      AutofillAccounts(); 
    }  
    private void button1_Click(object sender, EventArgs e)
    {
      checkBox1.Checked = true;
      Task t = new Task(() => GetsalesFigures()); t.Start();
    }
    private void GetsalesFigures()
    {
      // (...)
      //pictureBox2.Visible = true; use SetPictureBoxVisibility
      SetPictureBoxVisibility(true);
      //checkBox1.Checked = true; use SetCheckBoxValue
      SetCheckBoxValue(true);
      // (...)
      SetCheckBoxValue(false);
      SetPictureBoxVisibility(false); 
      // (...)
    }
    private void AutofillAccounts()
    {
     // Your implementation
    }
    private void SetCheckBoxValue(bool IsChecked)
    {
      if (checkBox1.InvokeRequired)
      {
        pictureBox2.Invoke(new Action<bool>(SetCheckBoxValue), new Object[] { IsChecked });
      }
      else
      {
        checkBox1.Checked = IsChecked;
      }
    }
    private void SetPictureBoxVisibility(bool IsVisible)
    {
      if (pictureBox2.InvokeRequired)
      {
        pictureBox2.Invoke(new Action<bool>(SetPictureBoxVisibility), new Object[] { IsVisible });
      }
      else
      {
        pictureBox2.Visible = IsVisible;
      }
    }
    // Your latest comment
     private void AddItem(string value)
     {
      if (accCollection.InvokeRequired)
      {
        accCollection.Invoke(new Action<bool>(AddItem), new Object[] {   value });
      }
      else
      {
        accCollection.Items.Add(value);
      }
    }
