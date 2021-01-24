    tt.Tick += (ss, ee) => {
      if (index > linesX.Count - 1) {
        tt.Stop();
      } else {
        Point p = new Point(int.Parse(linesX[index]), int.Parse(linesY[index]));
        Cursor.Position = resolution.PointToScreen(p);
      }
      index++;
    }
