    void DrawShape(Shape MyShape, Point MyStartpoint, Point MyEndpoint)
            {
                if (CreateRectangle)
                {
                    MyShape.Stroke = new SolidColorBrush(SetColor);
                    MyShape.Stroke.Opacity = 0.1;
                    MyShape.Fill = new SolidColorBrush(SetColor);
                    MyShape.Fill.Opacity = 0;
                    MyShape.StrokeThickness = 2;
                if (DrawMode)
                {
                    Temp = End;
                    DrawMode = false;
                }
                    if (Temp.X < MyEndpoint.X && Temp.Y < MyEndpoint.Y)
                    {
                        MyShape.SetValue(Canvas.LeftProperty, MyStartpoint.X);
                        MyShape.SetValue(Canvas.TopProperty, MyStartpoint.Y);
                    }
                    else if (Temp.X > MyEndpoint.X && Temp.Y < MyEndpoint.Y)
                    {
                        double LeftX = MyStartpoint.X - (Temp.X - MyEndpoint.X);
                        MyShape.SetValue(Canvas.LeftProperty, LeftX);
                        MyShape.SetValue(Canvas.TopProperty, MyStartpoint.Y);
                    }
                    else if (Temp.X < MyEndpoint.X && Temp.Y > MyEndpoint.Y)
                    {
                        double TopY = MyStartpoint.Y - (Temp.Y - MyEndpoint.Y);
                        MyShape.SetValue(Canvas.LeftProperty, MyStartpoint.X);
                        MyShape.SetValue(Canvas.TopProperty, TopY);
                    }
                    else if (Temp.X > MyEndpoint.X && Temp.Y > MyEndpoint.Y)
                    {
                        double LeftX = MyStartpoint.X - (Temp.X - End.X);
                        double TopY = MyStartpoint.Y - (Temp.Y - End.Y);
                        MyShape.SetValue(Canvas.LeftProperty, LeftX);
                        MyShape.SetValue(Canvas.TopProperty, TopY);
                    }
                    if (MyStartpoint.X > MyEndpoint.X)
                    {
                        MyShape.Width = MyStartpoint.X - MyEndpoint.X;
                    }
                    else
                    {
                        MyShape.Width = MyEndpoint.X - MyStartpoint.X;
                    }
                    if (MyStartpoint.Y > MyEndpoint.Y)
                    {
                        MyShape.Height = MyStartpoint.Y - MyEndpoint.Y;
                    }
                    else
                    {
                        MyShape.Height = MyEndpoint.Y - MyStartpoint.Y;
                    }
                    //Buttondown = false;
                    //diagram.Children.Add(MyShape);
                }
            }
