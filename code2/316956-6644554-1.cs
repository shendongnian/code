    protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
   
        string namers="";
    
        NavigationContext.QueryString.TryGetValue("name", out namers)
        
        Textblock.Text = namers;
       
    }
