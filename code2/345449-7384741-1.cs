    private void theBookListBox_Hold(object sender, GestureEventArgs e)
    {
    
      AppState state = ThisApp._appState;
        if (e.OriginalSource is TextBlock)
        {
            if (((string)((e.OriginalSource as TextBlock).Name)) == "btBookName")
            {
                LoadBookXML();
                Your other code here...
            }
        }
    }
