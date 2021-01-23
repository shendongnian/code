       Keys MyKey;
            bool KeyIsDown = false;
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (KeyIsDown)
                {
                    e.Handled = true;
                }
                else
                {
                    MyKey = e.KeyData;
                }
            }
    
            private void Form1_KeyUp(object sender, KeyEventArgs e)
            {
                if (KeyIsDown)
                {
                    if (e.KeyData == MyKey)
                    {
                        KeyIsDown = false;
                    }
                }
            }
