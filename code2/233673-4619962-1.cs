    void ButtonClick(object sender, RoutedEvent e)
    {
       Label label = new Label();
       listBox1.Items.Add(label);       
       Task.Factory.StartNew(() =>
       {
           for (int i = 0; i < 100; i++)
           {
              label.Content = (i + 1).ToString() + "%";
           }
       });
    }
