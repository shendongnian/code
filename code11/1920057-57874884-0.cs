    var rootObject = JsonConvert.DeserializeObject<Rootobject>(Response);
    foreach (var item in rootObject.tables)
        {
           int rows = item.rows.GetLength(0);
           int columns = item.rows[0].GetLength(0);
            int row = 0;
            int column = 0;
            while (row++ < rows-1)
            {
                
                while (column++ < columns-1)
                {
                    Console.WriteLine(item.columns[column] + ":" + item.rows[row][column]);
                }
                column = 0;
            }
        }
