    public App(string _pdfUri)
        {
            InitializeComponent();   
            if(path !=null){
               MainPage = new NavigationPage(new LoginPage(_pdfUri))
                {
                    BarBackgroundColor = Color.FromHex("008000"),
                    BarTextColor = Color.FromHex("E8E8E8")
                };    
            }else{
               MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = Color.FromHex("008000"),
                    BarTextColor = Color.FromHex("E8E8E8")
                };     
            }
                  
        }
