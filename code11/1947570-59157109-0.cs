               //Button is an instance of a Rectangle.
               button = (sender as Rectangle); 
               Console.WriteLine("Dans le handler");
               do
                {
                    Console.WriteLine(Mouse.GetPosition(button));
              
                    //MessageBox.Show("a cliqué");
                    point = Mouse.GetPosition(button);
                    
                    //  Console.WriteLine(button.Width );
                    if (e.ChangedButton == MouseButton.Left)
                    {
                        Console.WriteLine("Cliqued for moving");
                        m_IsPressed = true;
                        isediting = false;
                    Mouse.OverrideCursor = Cursors.Hand;
                }
                    else
                    {
                        m_IsPressed = false;
                    }
                    if (point.X > 0 && point.X < button.Width && point.Y <= button.Height 
                    && point.Y > button.Height - 10)
                    {
                    Console.WriteLine("Cliqued for editing");
                        m_IsPressed = true;
                        isediting = true;
                    Mouse.OverrideCursor = Cursors.SizeNWSE;
                    }
                
            }
            while (button.IsMouseCaptured);
        }
