    for (int i = 0; i < txtbxURL.LineCount; i++)
    {
        mytest.NavigateTo(mytest.strURL);
        mytest.SetupWebDoc(mytest.strURL);
        strOutput = mytest.PullOutPutText(mytest.strURL);
        strOutput = mytest.Tests(strOutput);
        mytest.CheckAlt(mytest.strURL);
        mytest.WriteError(txtbxWriteFile.Text);
        txtblCurrentURL.Text = mytest.strURL;
        //This ^^^ is what is being updated, which keeps the thread from throwing the exception noted above.
    }
          
