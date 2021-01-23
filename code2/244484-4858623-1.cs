    // Define the settings binding source
    private System.Windows.Forms.BindingSource settingsBindingSource;
     private void InitializeComponent()
      {
                this.components = new System.ComponentModel.Container();
                this.durationTextBox = new System.Windows.Forms.TextBox();
                this.settingsBindingSource = new BindingSource(this.components);
                this.settingsBindingSource.DataSource = typeof(WindowsFormsApplication1.Properties.Settings);
                this.durationTextBox.DataBindings.Add(new Binding("Text", this.settingsBindingSource, "Duration", true));
      }
    
    // In the form load event where the textbox is displayed
    private void Form1_Load(object sender, System.EventArgs e)
    {
       settingsBindingSource.DataSource = Settings.Default;
    }
    
    // save button click
    private void button1_Click_1(object sender, System.EventArgs e)
    {
       // This saved the settings, without any exceptions
       Settings.Default.Save();
    }
