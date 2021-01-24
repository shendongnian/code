    private void ComboBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        Brush brush = null;
        var g = e.Graphics;
        if (e.Index >= 0)
        {
            string item = ((ComboBox)sender).Items[e.Index].ToString();
            switch (item)
            {
                case "A faire":
                    brush = Brushes.DeepSkyBlue;
                    break;
                case "En cours":
                    brush = Brushes.HotPink;
                    break;
                case "interrompue":
                    brush = Brushes.Gold;
                    break;
                case "Terminée":
                    brush = Brushes.SpringGreen;
                    break;
                case "Annulée":
                    brush = Brushes.LightGray;
                    break;
            }
            g.DrawString(item, e.Font, brush, e.Bounds);
            e.DrawFocusRectangle();
        }
    }
    
