                SwinGame.ClearScreen(Color.White);
                
                if (SwinGame.MouseClicked(MouseButton.LeftButton))
                {
                    myShape.X = SwinGame.MouseX();
                    myShape.Y = SwinGame.MouseY();
                    myShape.Color = Color.Green;
                    myShape.Width = 10;
                    myShape.Height = 10;
                    myShape.Draw();
                }
           
