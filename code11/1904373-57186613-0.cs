    public MainWindow()
    {
        InitializeComponent();
        textBox.AcceptsTab = true;
    }
    private void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            // append newline AND maybe some tabs
            textBox.AppendText(DoEnterPressed());
        }
        if (e.Key == Key.Tab && e.Key == Key.LeftShift)
        {
            // check, see and do
            DoShiftTab();
        }
    }
    
    //now we need those methods of course
    private string DoEnterPressed()
    {
        string ret = Environment.NewLine;
        //check how many tabs the line has...
       
        //I want the line we are on, not maybe the last line    
        string currentLine = textBox.GetLineText(textBox.GetLineIndexFromCharacterIndex(textBox.SelectionStart) );
        //  Only counting the tab chars at the start of string makes it easier
        int tabCnt = 0;
        foreach(char c in currentLine)
        {
            if(c == '\t')
            {
                tabCnt++;
            }
            else
            {
                break;
            }
        }
        // now put the tabs in the return string after the newline
        for(int i = 0; i < tabCnt; i++)
        {
            ret += "\t";
        }
        return ret;
    }
    private void DoShiftTab()
    {
        //  let's see if the char before the cursor is tab, if so, remove it
        if(textBox.text[textBox.SelectionStart-1] == '\t')
        {
            textBox.text.RemoveAt(textBox.SelectionStart-1);
        }
    }
