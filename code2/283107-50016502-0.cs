    SendMessageGmail(oMess);
    if(oMess.Attachments != null) {
      for(Int32 I = oMess.Attachments.Count - 1; I >= 0;I--) {
        oMess.Attachments[i].Dispose();
      }
      oMess.Attachments.Clear();
      oMess.Attachments.Dispose();
    }
    oMess.Dispose();
    oMess = null;
