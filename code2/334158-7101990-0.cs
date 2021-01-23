            public MainPage()
        {
            InitializeComponent();
            if (someVariable == 0)
            {
                myPopup = new Popup() { IsOpen = true, Child = new Login() };
                someVariable = 1; //this will be a global value, so the popup wouldn't open again when back key is pressed
            }
            
        }
