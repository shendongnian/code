`
for(int i = 0; i < array.GetLength(1); i++)
        {
            int x = 0;
            for (int j = 1; j < array.GetLength(1); j++) {
                x += array[j, i]
            }
            chart1.Series.Add(array[0, i]);
            chart1.Points.AddXY(array[0, i], x);
        }
`
