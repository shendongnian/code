            Color[] myPalette = new Color[5]{ 
                 Color.FromArgb(255,101,187,226), 
                 Color.FromArgb(255,253,214,91), 
                 Color.FromArgb(255,38,190,151), 
                 Color.FromArgb(255,253,183,101),
                 Color.FromArgb(255,218,143,183)};
            chart.Palette = ChartColorPalette.None;
            chart.PaletteCustomColors = myPalette;
            //Loop over the data and add it to the series
            int i = 0;
            foreach (var item in data)
            {
                chart.Series[0].Points.AddXY(item.Key, Convert.ToDouble(item.Value));
                chart.Series[0].Points[i].BackGradientStyle = GradientStyle.Center;
                chart.Series[0].Points[i].Color = myPalette[i];
                chart.Series[0].Points[i].BackSecondaryColor = LightenColor(myPalette[i]);
                //chart.Series[0].Points[i].SetCustomProperty("Exploded","true");
                i++;
            }
