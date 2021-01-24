    private  void English_Clicked(object sender, EventArgs e)    
    {    
        Button english = (Button)sender;       
        english.BorderColor = Color.FromHex("#da2c43");  
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(20000);
    
            english.BorderColor = Color.FromHex("");  
        });  
    }
