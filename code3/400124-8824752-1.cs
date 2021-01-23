    var sbChatData = new System.Text.StringBuilder(1000);
    while(dr.read())
    {
       sbChatData.AppendLine(dr[0].ToString());
    }
    divChat.InnerText += sbChatData.ToString();
