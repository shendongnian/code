    void ButtonClick(object sender, RoutedEvent e)
    {
       Task.Factory.StartNew(() =>
       {
           Label label = new Label();
           listBox1.Items.Add(label);
           
           for (int i = 0; i < 100; i++)
           {
              label.Content = (i + 1).ToString() + "%";
           }
       });
    }
