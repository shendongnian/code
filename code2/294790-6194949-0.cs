    public partial class Form1 : Form
    {
      byte[,] tiles;
      const int rows = 50;
      const int cols = 50;
      public Form1()
      {
         SetStyle(ControlStyles.ResizeRedraw, true);
         InitializeComponent();
         tiles = new byte[cols, rows];
         for (int i = 0; i < 10; i++)
         {
            tiles[20, i+20] = 1;
            tiles[23, i+20] = 1;
            tiles[32, i+20] = 1;
            tiles[35, i+20] = 1;
            tiles[i + 23, 30] = 1;
            tiles[i + 23, 32] = 1;
            tiles[21, i + 15] = 2;
            tiles[21, i + 4] = 2;
            if (i % 2 == 0) tiles[22, i] = 2;
         }
         tiles[20, 30] = 1;
         tiles[20, 31] = 1;
         tiles[20, 32] = 1;
         tiles[21, 32] = 1;
         tiles[22, 32] = 1;
         tiles[33, 32] = 1;
         tiles[34, 32] = 1;
         tiles[35, 32] = 1;
         tiles[35, 31] = 1;
         tiles[35, 30] = 1;
      }
      protected override void OnPaint(PaintEventArgs e)
      {
         base.OnPaint(e);
         using (SolidBrush b = new SolidBrush(Color.White))
         {
            for (int y = 0; y < rows; y++)
            {
               for (int x = 0; x < cols; x++)
               {
                  switch (tiles[x, y])
                  {
                     case 0:
                        b.Color = Color.White;
                        break;
                     case 1:
                        b.Color = Color.Black;
                        break;
                     default:
                        b.Color = Color.Blue;
                        break;
                  }
                  e.Graphics.FillRectangle(b, x * ClientSize.Width / cols, y * ClientSize.Height / rows,
                     ClientSize.Width / cols + 1, ClientSize.Height / rows + 1);
               }
            }
         }
      }
      private bool IsLiquid(int x, int y)
      {
         return tiles[x, y] > 1;
      }
      private bool IsSolid(int x, int y)
      {
         return tiles[x, y] == 1;
      }
      private bool IsEmpty(int x, int y)
      {
         return IsEmpty(tiles, x, y);
      }
      public static bool IsEmpty(byte[,] tiles, int x, int y)
      {
         return tiles[x, y] == 0;
      }
      private void ProcessTiles()
      {
         byte processedValue = 0xFF;
         byte unprocessedValue = 0xFF;
         for (int y = 0; y < rows; y ++)
            for (int x = 0; x < cols; x++)
            {
               if (IsLiquid(x, y))
               {
                  if (processedValue == 0xff)
                  {
                     unprocessedValue = tiles[x, y];
                     processedValue = (byte)(5 - tiles[x, y]);
                  }
                  if (tiles[x, y] == unprocessedValue)
                  {
                     BlobInfo blob = GetWaterAt(new Point(x, y), unprocessedValue, processedValue, new Rectangle(0, 0, 50, 50));
                     blob.ProcessMovement(tiles);
                  }
               }
            }
      }
      class BlobInfo
      {
         private int minY;
         private int maxEscapeY;
         private List<int> TopXes = new List<int>();
         private List<int> BottomEscapeXes = new List<int>();
         public BlobInfo(int x, int y)
         {
            minY = y;
            maxEscapeY = -1;
            TopXes.Add(x);
         }
         public void NoteEscapePoint(int x, int y)
         {
            if (maxEscapeY < 0)
            {
               maxEscapeY = y;
               BottomEscapeXes.Clear();
            }
            else if (y < maxEscapeY)
               return;
            else if (y > maxEscapeY)
            {
               maxEscapeY = y;
               BottomEscapeXes.Clear();
            }
            BottomEscapeXes.Add(x);
         }
         public void NoteLiquidPoint(int x, int y)
         {
            if (y < minY)
            {
               minY = y;
               TopXes.Clear();
            }
            else if (y > minY)
               return;
            TopXes.Add(x);
         }
         public void ProcessMovement(byte[,] tiles)
         {
            int min = TopXes.Count < BottomEscapeXes.Count ? TopXes.Count : BottomEscapeXes.Count;
            for (int i = 0; i < min; i++)
            {
               if (IsEmpty(tiles, BottomEscapeXes[i], maxEscapeY) && (maxEscapeY > minY))
               {
                  tiles[BottomEscapeXes[i], maxEscapeY] = tiles[TopXes[i], minY];
                  tiles[TopXes[i], minY] = 0;
               }
            }
         }
      }
      private BlobInfo GetWaterAt(Point start, byte unprocessedValue, byte processedValue, Rectangle bounds)
      {
         Stack<Point> toFill = new Stack<Point>();
         BlobInfo result = new BlobInfo(start.X, start.Y);
         toFill.Push(start);
         do
         {
            Point cur = toFill.Pop();
            while ((cur.X > bounds.X) && (tiles[cur.X - 1, cur.Y] == unprocessedValue))
               cur.X--;
            if ((cur.X > bounds.X) && IsEmpty(cur.X - 1, cur.Y))
               result.NoteEscapePoint(cur.X - 1, cur.Y);
            bool pushedAbove = false;
            bool pushedBelow = false;
            for (; ((cur.X < bounds.X + bounds.Width) && tiles[cur.X, cur.Y] == unprocessedValue); cur.X++)
            {
               result.NoteLiquidPoint(cur.X, cur.Y);
               tiles[cur.X, cur.Y] = processedValue;
               if (cur.Y > bounds.Y)
               {
                  if (IsEmpty(cur.X, cur.Y - 1))
                  {
                     result.NoteEscapePoint(cur.X, cur.Y - 1);
                  }
                  if ((tiles[cur.X, cur.Y - 1] == unprocessedValue) && !pushedAbove)
                  {
                     pushedAbove = true;
                     toFill.Push(new Point(cur.X, cur.Y - 1));
                  }
                  if (tiles[cur.X, cur.Y - 1] != unprocessedValue)
                     pushedAbove = false;
               }
               if (cur.Y < bounds.Y + bounds.Height - 1)
               {
                  if (IsEmpty(cur.X, cur.Y + 1))
                  {
                     result.NoteEscapePoint(cur.X, cur.Y + 1);
                  }
                  if ((tiles[cur.X, cur.Y + 1] == unprocessedValue) && !pushedBelow)
                  {
                     pushedBelow = true;
                     toFill.Push(new Point(cur.X, cur.Y + 1));
                  }
                  if (tiles[cur.X, cur.Y + 1] != unprocessedValue)
                     pushedBelow = false;
               }
            }
            if ((cur.X < bounds.X + bounds.Width) && (IsEmpty(cur.X, cur.Y)))
            {
               result.NoteEscapePoint(cur.X, cur.Y);
            }
         } while (toFill.Count > 0);
         return result;
      }
      private void timer1_Tick(object sender, EventArgs e)
      {
         ProcessTiles();
         Invalidate();
      }
      private void Form1_MouseMove(object sender, MouseEventArgs e)
      {
         if (e.Button == MouseButtons.Left)
         {
            int x = e.X * cols / ClientSize.Width;
            int y = e.Y * rows / ClientSize.Height;
            if ((x >= 0) && (x < cols) && (y >= 0) && (y < rows))
               tiles[x, y] = 2;
         }
      }
    }
