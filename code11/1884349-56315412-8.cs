    public ObservableCollection<Item> MediaList { get; set; } = new ObservableCollection<Item>()
            {
                new Item
                {
                    ImageSource = ImageSource.FromFile("xamarin.png")
                },
                new Item
                {
                    ImageSource = ImageSource.FromUri(new Uri("https://i.stack.imgur.com/4mMod.png"))
                }
            };
