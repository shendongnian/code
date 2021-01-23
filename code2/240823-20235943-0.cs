        //Add Column Call It Ser
        //Set It To ReadOnly=false
        
       // Add This Code To Your Application
        
            if (GridSearch.Rows.Count > 1)
                            {
                                for (int i = 0; i < GridSearch.Rows.Count-1; i++)
                                {
                                    GridSearch.Rows[i].Cells[0].Value = (i + 1).ToString();
                                }
                            }
