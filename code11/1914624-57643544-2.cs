    public ObservableCollection<Point> points { get; set; } = new ObservableCollection<Point>();
    internal void ExcelFileOpen(object sender, System.EventArgs e)
    {
        // Do not re-initialise the collection anymore.
        //points = new ObservableCollection<Point> { new Point { } };
        points.Add(new Point { name = "point1", code = 1 });
        points.Add(new Point { name = "point2", code = 2 });
        points.Add(new Point { name = "point3", code = 3 });
    }
