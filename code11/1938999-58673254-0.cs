    Tile = new MyPictureBox[rowCount, columnCount];
            for (int colNumber = 0; colNumber < columnCount; colNumber++)
            {
                int actualColumn = colNumber;
                int actualRow = rowNumber; 
    
                Tile[rowNumber, colNumber] = new MyPictureBox();
                ...
                Tile[rowNumber, colNumber].Click += new EventHandler((sender,e) => LoadImage_Click(sender, e, actualRow, actualColumn));
                this.Controls.Add(Tile[rowNumber, colNumber]);
                leftPosition += width;
            }
