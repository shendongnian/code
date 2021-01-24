     public Data(UserResponse result)
        {
            //show = test;
            InitializeComponent();
            obj = result.Data;
            if (!string.IsNullOrEmpty(obj.avatar))
            {
                Img = ImageSource.FromUri(new Uri(obj.avatar));
            }
        }
