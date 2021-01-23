        private int _CursorHideCounter;
        public bool CursorShown
        {
            get
            {
                return _CursorHideCounter == 0;
            }
            set
            {
                if (value && _CursorHideCounter == 0)
                {
                    return;
                }
                int counter = _CursorHideCounter;
                _CursorHideCounter += value ? -1 : 1;
                if (counter == 0 && _CursorHideCounter > 0)
                {
                    System.Windows.Forms.Cursor.Hide();
                }
                else if (counter > 0 && _CursorHideCounter == 0)
                {
                    System.Windows.Forms.Cursor.Show();
                }
            }
        }
