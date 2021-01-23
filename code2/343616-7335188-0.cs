    private void DoStuff(string TextIWouldBeRemoving)
    {        
        if (listboxname.InvokeRequired)
        {
            listboxname.Invoke(DoStuff, new object[] { TextIWouldBeRemoving )};   
        }
        else
        {
            // Actually remove the text here!
        }
    }
