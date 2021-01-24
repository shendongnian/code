    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MoveStoryboard.Begin();        
    }
    public double TbkY { get; set; }
    
    private void Tbk_Loaded(object sender, RoutedEventArgs e)
    {
        TbkY = -Tbk.ActualOffset.Y;
    }
