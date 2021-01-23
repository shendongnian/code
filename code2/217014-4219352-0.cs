        public static void DrawDashedLine(this Graphics g, Pen p, float dash, float gap, PointF s, PointF e)
        {
          float dx = e.X - s.X;
          float dy = e.Y - s.Y;
    
          float len = (float)Math.Sqrt(dx * dx + dy * dy);
          float remainder = len;
    
          float vx = dx / len;
          float vy = dy / len;
    
          if (len <= dash + gap)
          {
            g.DrawLine(p, s, e);
            return;
          }
    
          PointF last = s;
    
          while (remainder > dash + gap)
          {
            PointF p1 = new PointF(last.X, last.Y);
            PointF p2 = new PointF(p1.X + vx*dash, p1.Y + vy*dash);
    
            g.DrawLine(p, p1, p2);
    
            last = new PointF(p2.X + vx*gap, p2.X + vy*gap);
    
            remainder = remainder - dash - gap;
          }
    
          if (remainder > 0)
          {
            g.DrawLine(p, last, e);
          }
        }
      }
