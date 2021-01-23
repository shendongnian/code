    private void btnSearch_Click(object sender, EventArgs e)
    {
      dataGridView1.ClearSelection();
      string strSearch = txtSearch.Text.ToUpper();
      int iIndex = -1;
      int iFirstFoundRow = -1;
      bool bFound = false;
      if (strSearch != "")
      {
        dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        /*  Select All Rows Starting With The Search string in row.cells[1] =
        second column. The search string can be 1 letter till a complete line
        If The dataGridView MultiSelect is set to true this will highlight 
        all found rows. If The dataGridView MultiSelect is set to false only 
        the last found row will be highlighted. Or if you jump out of the  
        foreach loop the first found row will be highlighted.*/
       foreach (DataGridViewRow row in dataGridView1.Rows)
       {
         if ((row.Cells[1].Value.ToString().ToUpper()).IndexOf(strSearch) == 0)
         {
           iIndex = row.Index;
           if(iFirstFoundRow == -1)  // First row index saved in iFirstFoundRow
           {
             iFirstFoundRow = iIndex;
           }
           dataGridView1.Rows[iIndex].Selected = true; // Found row is selected
           bFound = true; // This is needed to scroll de found rows in display
           // break; //uncomment this if you only want the first found row.
         }
       }
       if (bFound == false)
       {
         dataGridView1.ClearSelection(); // Nothing found clear all Highlights.
       }
       else
       {
         // Scroll found rows in display
         dataGridView1.FirstDisplayedScrollingRowIndex = iFirstFoundRow; 
       }
    }
  } 
