        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // These keys will be allowed
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                case Keys.Escape:
                case Keys.Enter:
                    break;
                // These keys will not be allowed
                default:
                    e.SuppressKeyPress = true;
                    break;
            }
        }
