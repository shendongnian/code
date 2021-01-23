    var list = new List<Rectangle>();
    for (int i = 0; i < 10; i++)
    {
        list.Add(new Rectangle());
    }
    var panel = new StackPanel();
    foreach (var rectangle in list)
    {
        panel.Children.Add(rectangle);
    }
