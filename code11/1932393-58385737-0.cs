    private void BTN_Click(object sender, RoutedEventArgs e)
    {
      try
      {
        load(textbox1.Text);
      }catch(Exception ex){ MessageBox.Show(ex.Message);}
    }
    void load(string _path)
    {
      int s = 1;
       while (s < 10)
       { if (condition == true)
          {
            XDocument mydocument = XDocument.Load(_path);
            string XML2Str = mydocument.ToString();
            if (XML2Str.Contains("bingo"))
              { //do stuff//}
          }
         s++;
      }
    }
