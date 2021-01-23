    class MyDataSource
    {
        // its value come from your database but now I will set it manually
        public String imgurl
        {
            get;
            set;
        }
        public Image img
        {
            get
            {
                return Image.FromFile(imgurl);
            }
        }
    }
