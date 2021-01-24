        <Border Margin="10,100,10,10" Background="AliceBlue">
            <ContentPresenter Name="contentFrame">
            </ContentPresenter>
        </Border>
        
        private void btn1(object sender, RoutedEventArgs e)
        {
            Grid grd = new Grid();
            grd.Background = new SolidColorBrush(Colors.HotPink);
            contentFrame.Content = grd; // replace me with your control / page / window1
        }
