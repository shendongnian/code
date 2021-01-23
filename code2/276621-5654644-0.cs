       void main()
        {
            Graphic graphic = new Graphic();
            hyperlinkButton.Tag = graphic;
            hyperlinkButton.Click+=new RoutedEventHandler(hyperlinkButton_Click);
        }
    
        void hyperlinkButton_Click(object sender, EventArgs e)
        {
           Graphic graphic =(sender as HyperlinkButton).Tag as Graphic;
        }
