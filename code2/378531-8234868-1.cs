    private void button1_Click(object sender, RoutedEventArgs e)
    {
        List<MyObject> list = new List<MyObject>();
        list.Add(new MyObject() { a = 1, b = 2, c = 3 });
        list.Add(new MyObject() { a = 4, b = 57346, c = 6 });
        list.Add(new MyObject() { a = 7, b = 8, c = 9 });
        listBox1.ItemsSource = list;
    }
