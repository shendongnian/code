    class TagData
    {
        public string Title {get; set; }
        public string Artist {get; set; }
        public string Album {get; set; }
    }
    
    class a{
       public TagData getContent(){
          return new TagData
          {
              Title = Encoding.Default.GetString(tag.Title),
              Artist = Encoding.Default.GetString(tag.Artist),
              Album = Encoding.Default.GetString(tag.Album)
          };
       }
    }
    
    class form1{
        button1.click()
        {
            var tagData = a.getContent
            text1.text = tagData.Title;
            text2.Text = tagData.Artist;
        }
    }
