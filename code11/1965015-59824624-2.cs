            rightTop.DragDelta += (sender, e) =>
            {
                double hor = e.HorizontalChange;
                double vert = e.VerticalChange;
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    double _max = Math.Abs(hor) > Math.Abs(vert) ? Math.Abs(hor) : Math.Abs(vert);
                    if( _max >50)return;//if distance of mouse from thumb is > 50pixel, no action
                    if (hor >= 0 && vert <= 0)    // review the tests
                    {
                        hor = _max;
                        vert = -_max;
                    }
                    else if(hor <= 0 && vert >=0)
                    {
                        hor = -_max;
                        vert = _max;
                    }
                    else
                    {
                        return;
                    }
                }
                ResizeWidth(hor);
                ResizeY(vert);
                e.Handled = true;
            };
            CreateThumbPart(ref leftBottom);
            leftBottom.DragDelta += (sender, e) =>
            {
                double hor = e.HorizontalChange;
                double vert = e.VerticalChange;
                if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
                {
                    double _max = Math.Abs(hor) > Math.Abs(vert) ? Math.Abs(hor) : Math.Abs(vert);
                    if( _max >50)return;
                    if (hor <= 0 && vert >= 0)  //same things
                    {
                        hor = -_max;
                        vert = _max;
                    }
                    else if (hor >= 0 && vert <= 0)
                    {
                        hor = _max;
                        vert = -_max;
                    }
                    else
                    {
                        return;
                    }
                }
                ResizeX(hor);
                ResizeHeight(vert);
                e.Handled = true;
            };
