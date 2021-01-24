        private void PlayMenu_KeyDown(object sender, KeyEventArgs e)
        {
            // I also refactored your if statements into a switch. It's a lot cleaner.
            switch (e.KeyCode)
            {
                case Keys.Left:
                    Position.X -= 10;
                    break;
                case Keys.Right:
                    Position.X += 10;
                    break;
                case Keys.Up:
                    Position.Y -= 10;
                    break;
                case Keys.Down:
                    Position.Y += 10;
                    break;
            }
       
        }
