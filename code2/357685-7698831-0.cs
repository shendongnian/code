    using System.Collections.Generic;
    // ...
    Dictionary<string,ChatWindow> windowDict = Dictionary<string,ChatWindow>();
    while (aFromReader.Read()) 
    {
        OleDbCommand aCommand = new OleDbCommand("select * from Messages",aConnection);
        OleDbDataReader aMessage = aCommand.ExecuteReader();
        string windowText = aFromReader.GetValue(0).ToString();
        if(windowDict.Contains(windowText))
        {
            // do something with windowDict[windowText]
        }
        else
        {
            tempwindow = new ChatWindow();
            tempwindow.Text = windowText;
            windowDict.Add(windowText,tempwindow);
            tempwindow.Show();
        }
    }
