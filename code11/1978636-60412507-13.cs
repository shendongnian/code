     public Data(UserResponse result)
        {
            //show = test;
            InitializeComponent();
            obj = result.Data;
            if (!string.IsNullOrEmpty(obj.avatar))
            {
                Img = await getImageSource(obj.avatar);
            }
        }
