        for (int i = 0; i < x.Length; i++) //xValues.Lenght = 4 in this case where you have 4 Data number
        {
            if (i == 0) // Don't forget xValues[0] is Data4 in your case
                DuesChart.Series[0].Points[i].Color = Color.Blue;
            if (i == 1)
                DuesChart.Series[0].Points[i].Color = Color.Yellow;
            if (i == 2)
                DuesChart.Series[0].Points[i].Color = Color.Violet;
            if (i == 3)
                DuesChart.Series[0].Points[i].Color = Color.SkyBlue;
            if (i == 4)
                DuesChart.Series[0].Points[i].Color = Color.Orange;
            if (i == 5)
                DuesChart.Series[0].Points[i].Color = Color.Green;
            if (i == 6)
                DuesChart.Series[0].Points[i].Color = Color.Pink;
            if (i == 7)
                DuesChart.Series[0].Points[i].Color = Color.Purple;
        }
        
       
    }
