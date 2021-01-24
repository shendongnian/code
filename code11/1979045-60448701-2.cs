    class DemoViewModel
        {
            public ObservableCollection<BindingUser> Data { get; set; }
    
            public DemoViewModel() {
                Data = new ObservableCollection<BindingUser>
                {
                    new BindingUser(1, "aa"),
                    new BindingUser(2, "bb"),
                    new BindingUser(3, "cc"),
                    new BindingUser(4, "dd")
                };
            }
    
        }
