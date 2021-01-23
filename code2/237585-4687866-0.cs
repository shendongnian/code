    class MainForm : Form
    {
        public void FindNext(string find)
        {
            // Do stuff
        }
    
        public void OpenFindWindow()
        {
            FindBox find = new FindBox(this.FindNext);
            find.Show();
        }
    }
    
    
    class FindBox : Form
    {
        private Action<string> callback;
    
        public FindBox(Action<string> callback)
        {
            this.callback = callback;
        }
        public void FindButtonPressed()
        {
            callback(textBox1.text);
        }
    }
