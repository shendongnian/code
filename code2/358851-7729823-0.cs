    for (int x = Math.Min(p1.X, p2.X); x <= Math.Max(p1.X, p2.X); x++){
      for (int y = Math.Min(p1.Y, p2.Y); y <= Math.Max(p1.Y, p2.Y); y++){
        MessageBox.Show(String.Format("{0} {1}", x, y));
      }
    }
