                public void ShowPoint(Point point)
                {
                    int y = point.Y;
                    for (int x = point.X - 60; x < point.X; x++)
                    {
                        this.Cursor = new Cursor(Cursor.Current.Handle);
   
                        System.Threading.Thread.Sleep(30);
                        Cursor.Position = new Point(x, y);
                        Cursor.Clip = new Rectangle(this.Location, this.Size);    
                    }
                }  
