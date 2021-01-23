        private void HideOnEvent(object sender, EventArgs e)
        {
            if (!WinAPI.GetTrayRectangle().Contains(Cursor.Position))
            {
                this.Hide();
            }
        }
