        border.MouseEnter += new MouseEventHandler(border_MouseEnter);
        
        void border_MouseEnter(object sender, MouseEventArgs e)
         {
            Button btn = new Button();
            btn.Click += new RoutedEventHandler(btn_Click);
         }
        void btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
