            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            static extern bool GetWindowRect(HandleRef hWnd, out RECT lpRect);
    
            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;        // x position of upper-left corner
                public int Top;         // y position of upper-left corner
                public int Right;       // x position of lower-right corner
                public int Bottom;      // y position of lower-right corner
            }
    
            Rectangle myRect = new Rectangle();
    
            private void button1_Click(object sender, System.EventArgs e)
            {
                RECT rct;
    
                if(!GetWindowRect(new HandleRef(this, this.Handle), out rct ))
                {
                    MessageBox.Show("ERROR");
                    return;
                }
                MessageBox.Show( rct.ToString() );
    
                myRect.X = rct.Left;
                myRect.Y = rct.Top;
                myRect.Width = rct.Right - rct.Left + 1;
                myRect.Height = rct.Bottom - rct.Top + 1;
            }
