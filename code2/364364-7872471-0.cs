    string text=txtEditor.Text;
    if(text.Trim.Length!=0)
    {
      using(System.IO.StreamWriter objStreamWriter = new System.IO.StreamWriter(File))
       {
           objStreamWriter.Write(text);
       }
    }
