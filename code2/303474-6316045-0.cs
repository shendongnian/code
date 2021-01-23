      StackPanel st = new StackPanel();
      st.Orientation = Orientation.Horizontal;
      TextBlock txtb = new TextBlock();
      txtb.Text = "New Tab";
      txtb.Margin = new Thickness(1, 1, 1, 1);
      txtb.VerticalAlignment = VerticalAlignment.Center;
      st.Children.Add(txtb);
      Button btn = new Button();
      btn.Content = "X";      
      st.Children.Add(btn);
      TabItem tbitem = new TabItem();
      // Set the header to the stack panel with the 
      // TextBlock and Button
      tbitem.Header = st;
      // This is where you define the content
      // of the tab page. Here I just added a Grid 
      // as an example.
      tbitem.Content = new Grid(); 
      
      tabControl1.Items.Add(tbitem);
