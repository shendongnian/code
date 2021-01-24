     // put this in your class where you will be using the new class
     private NavigateFile NavigateFile { get; set; } = new NavigateFile();
     // Load a file
     listBox1.Items.Clear();
     NavigateFile.LoadFile();
     listBox1.Items.Add(NavigateFile.GoToFirstLine());
     // Go to first line
     listBox1.Items.Clear();
     listBox1.Items.Add(NavigateFile.GoToFirstLine());
     // Go to next line
     listBox1.Items.Clear();
     listBox1.Items.Add(NavigateFile.GoToNextLine());
     // Go to previous line
     listBox1.Items.Clear();
     listBox1.Items.Add(NavigateFile.GoToPreviousLine());
     // Go to last line in the file
     listBox1.Items.Clear();
     listBox1.Items.Add(NavigateFile.GoToLastLine());
