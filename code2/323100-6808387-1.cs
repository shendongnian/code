    private void Button_Click(object sender, RoutedEventArgs e)
    {
      double top1 = (double)b1.GetValue(Canvas.TopProperty);
      double left1 = (double)b1.GetValue(Canvas.LeftProperty);
      Rect rect1 = new Rect(left1, top1, b1.Width, b1.Height);
       
      double top2 = (double)b2.GetValue(Canvas.TopProperty);
      double left2 = (double)b2.GetValue(Canvas.LeftProperty);
      Rect rect2 = new Rect(left2, top2, b2.Width, b2.Height);
      
      double top3 = (double)b3.GetValue(Canvas.TopProperty);
      double left3 = (double)b3.GetValue(Canvas.LeftProperty);
      Rect rect3 = new Rect(left3, top3, b3.Width, b3.Height);
      
      double top4 = (double)b4.GetValue(Canvas.TopProperty);
      double left4 = (double)b4.GetValue(Canvas.LeftProperty);
      Rect rect4 = new Rect(left4, top4, b4.Width, b4.Height);
      
      bool rc0 = rect1.IntersectsWith(rect4);
      bool rc1 = rect1.IntersectsWith(rect2);
      bool rc2 = rect2.IntersectsWith(rect3);
      bool rc3 = rect3.IntersectsWith(rect1);
      bool rc4 = rect2.IntersectsWith(rect4);
    }
