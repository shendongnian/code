    class a{
       public Dictionary<string, string> getContent(){
          var tagData = new Dictionary<string, string>();
          tagData["Title"] = Encoding.Default.GetString(tag.Title);
          tagData["Artist"] = Encoding.Default.GetString(tag.Artist);
          tagData["Album"] = Encoding.Default.GetString(tag.Album);
          return tagData;
       }
    }
    
    class form1{
        button1.click()
        {
            var tagData = a.getContent();
            text1.Text = tagData["Title"];
            text2.Text = tagData["Artist"];
        }
    }
