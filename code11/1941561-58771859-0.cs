    private void ActionCreatePoints_Click(object sender, EventArgs e)
    {
      if ( Properties.Settings.Default.Points == null )
        Properties.Settings.Default.Points = new Points();
      Properties.Settings.Default.Points.Add(new Point(10, 10));
      Properties.Settings.Default.Points.Add(new Point(20, 20));
      Properties.Settings.Default.Save();
    }
    private void ButtonViewPoints_Click(object sender, EventArgs e)
    {
      string str = "";
      foreach ( var point in Properties.Settings.Default.Points )
        str += $"{point.X},{point.Y}" + Environment.NewLine;
      MessageBox.Show(str.TrimEnd(Environment.NewLine.ToCharArray()));
    }
