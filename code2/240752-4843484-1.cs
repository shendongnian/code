    > var origin = new ScatterViewItem();
    > var destination = new
    > ScatterViewItem(); Line line = new
    > Line { Stroke = Brushes.Black,
    > StrokeThickness = 2.0 };
    > BindLineToScatterViewItems(line,
    > origin, destination);
    > 
    > ScatterView.Items.Add(origin);
    > ScatterView.Items.Add(destination);
    > LineHost.Children.Add(line);
