    bool isDuplicate;
    for(int nbRow = 0; nbRow < DataGridView1.Rows.Count; nbRow++)
    {
        for(int nbRowCompare = nbRow; nbRowCompare < DataGridView1.Rows.Count; nbRowCompare++)
        {
            isDuplicate = true;
            for(int nbCol = 0; nbCol < DataGridView1.Rows[nbRow].Cells.Count; nbCol++)
            {
                if(DataGridView1[nbCol, nbRow].Value != DataGridView1­[nbCol, nbRowCompare])
                {
                    isDuplicate = false;
                    break;     //Exit for each column if they are not duplicate
                }
            }
            if(isDuplicate)
            {
                 //Do something
            }
        }
    }
