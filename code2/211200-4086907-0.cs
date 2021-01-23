                int intX = 0, intY = 0;
                if(int.TryParse(listviewX.SubItems[ColumnToSort].Text, out intX)
                    && int.TryParse(listviewY.SubItems[ColumnToSort].Text, out intY))
                {
                    return intX.CompareTo(inty);
                }
           
