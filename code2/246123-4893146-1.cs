    List<string> listcollection = new List<string>();
    string myText = string.Empty;
    for (int i = 0; i < listcollection.Count; i++) {
       myText += ("string no. " + (i - 1).ToString() + ": " + listcollection[i] + Environment.NewLine);
    }
    MsgLabel.Text = myText;
