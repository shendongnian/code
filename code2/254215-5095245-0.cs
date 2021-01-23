    using (Graphics g = this.CreateGraphics() )
    {
         for (int i = 0; i < 350; i++)
         {
            g.Clear(Color.CadetBlue);
            g.DrawImage(Properties.Resources._256, 100, 100, i-150, i-150);
         }
    }
