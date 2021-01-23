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
      string acct = accCollection.Text;
      Task t = new Task(() => GetsalesFigures(acct)); 
      t.Start();
    }
    private void GetsalesFigures(String Acct)
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
      acct = Acct;
     // (...)
     SetDataGrid(true, dataSet1, "Pareto", DataGridViewAutoSizeColumnsMode.AllCells);
    }
    private void AutofillAccounts()
    {
       // (...)
       while (readacc.Read())             
        {                 
          AddItem(readacc.GetString(0).ToString());             
        }
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
        accCollection.Invoke(new Action<string>(AddItem), new Object[] {   value });
      }
      else
      {
        accCollection.Items.Add(value);
      }
    }
    private void SetDataGrid(bool AutoGenerateColumns, Object DataSource, String DataMember, DataGridViewAutoSizeColumnsMode Mode)
    {
      if (this.dataGridView1.InvokeRequired)
      {
        this.dataGridView1.Invoke(new Action<bool, Object, String,   DataGridViewAutoSizeColumnsMode>(SetDataGrid),
                                  AutoGenerateColumns, DataSource, DataMember, Mode);
      }
      else
      {
        this.dataGridView1.AutoGenerateColumns = AutoGenerateColumns;
        this.dataGridView1.DataSource = DataSource;
        this.dataGridView1.DataMember = DataMember;
        dataGridView1.AutoResizeColumns(Mode);
      }
    }
