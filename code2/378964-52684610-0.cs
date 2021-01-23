        private void btnName_Paint(object sender, PaintEventArgs e)
        {
            Button btn = (Button)sender;
            ControlPaint.DrawBorder(e.Graphics, btn.ClientRectangle,
                                    Color.LightGreen, 1, ButtonBorderStyle.Solid,
                                    Color.LightGreen, 1, ButtonBorderStyle.Solid,
                                    Color.LightGreen, 1, ButtonBorderStyle.Solid,
                                    Color.LightGreen, 1, ButtonBorderStyle.Solid
                                    );
        }
