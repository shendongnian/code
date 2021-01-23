        private void ShowColorDialog()
        {
            ColorDialog cd = new ColorDialog();
            cd.CustomColors = new int[] { ToInt(Color.Red), ToInt(Color.Blue), ToInt(Color.YellowGreen) };
            cd.SolidColorOnly = true;
            cd.ShowDialog();
        }
        static int ToInt(Color c)
        {
            return c.R + c.G * 0x100 + c.B * 0x10000;
        }
