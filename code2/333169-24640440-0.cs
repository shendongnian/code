    //This delegate will help us access the UI thread
    delegate void dUpdateTextBox(string text);
    //You'll need class-scope references to your variables
    private MyData myData;
    private TextBox textBox;
    static void Main(string[] args)
    {
        // Initialize the data and bindingSource
        myData = new MyData();
        myData.PropertyChanged += MyData_PropertyChanged;
        // Initialize the form and the controls of it ...
        var form = new Form();
        // ... the TextBox including data bind to it
        textBox = new TextBox();
        textBox.Dock = DockStyle.Top;
        form.Controls.Add(textBox);
        // ... the button and what happens on a click
        var button = new Button();
        button.Text = "Click me";
        button.Dock = DockStyle.Top;
        form.Controls.Add(button);
        button.Click += (_, __) =>
        {
            // Create another thread that does something with the data object
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (___, ____) => button.Enabled = true;
            worker.DoWork += (___, _____) =>
            {
                for (int i = 0; i < 10; i++)
                {
                    myData.MyText = "Try " + i;
                }
            };
            button.Enabled = false;
            worker.RunWorkerAsync();
        };
        form.ShowDialog();
    }
    
    //This handler will be called every time "MyText" is changed
    private void MyData_PropertyChanged(Object sender, PropertyChangedEventArgs e)
    {
        if((MyData)sender == myData && e.PropertyName == "MyText")
        {
            //If we are certain that this method was called from "MyText",
            //then update the UI
            UpdateTextBox(((MyData)sender).MyText);
        }
    }
    private void UpdateTextBox(string text)
    {
        //Check to see if this method call is coming in from the UI thread or not
        if(textBox.RequiresInvoke)
        {
            //If we're not on the UI thread, invoke this method from the UI thread
            textBox.BeginInvoke(new dUpdateTextBox(UpdateTextBox), text);
            return;
        }
        
        //If we've reached this line of code, we are on the UI thread
        textBox.Text = text;
    }
