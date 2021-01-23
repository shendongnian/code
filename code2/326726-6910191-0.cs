    int tbl1Index = 0;
    int tbl1Rows = dataset1.Tables[0].Rows.Count;
    int tbl2Index = 0;
    int tbl2Rows = dataset2.Tables[0].Rows.Count;
    DataRow row;
    // Do this loop until either tbl1 has been gone through completely or table 2 has been gone 
    // through completely, whichever comes first.
    while (tbl1Index < tbl1Rows && tbl2Index < tbl2Rows)
    {
        if (dataset1.Tables[0].Rows[tbl1Index]["A"].ToString() == "Y")
        {
            // Copy the next available row from table 2
            row = dataset2.Tables[0].Rows[tbl2Index];
            // Insert this row after the current row in table 1
            dataset1.Tables[0].Rows.InsertAt(row, tbl1Index + 1);
            // Increment the tbl1Index.  We increment it here because we added a row, even 
            // though we'll increment tbl1Index again before the next iteration of the while loop
            tbl1Index++;
            // Since we just inserted a row, we need to increase the count of rows in table 1 to
            // avoid premature exit of the while loop
            tbl1Rows++;
            // Increment tbl2Index so the next time a match occurs, the next row will be grabbed.
            tbl2Index++;
        }
      
        // Increment tbl1Index.  If there was a match above, we'll still need to increment to
        // account for the new row.  
        tbl1Index++;
    }
