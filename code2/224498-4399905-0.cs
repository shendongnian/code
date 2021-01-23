            public void RemoveRows()
            {
                Excel.Range rng =  Application.get_Range("A1", "A10");
                List<int> rowsMarkedForDeletion = new List<int>();
    
                for(int i = 0; i < rng.Rows.Count; i++)
                {
                    if(Application.WorksheetFunction.CountA(rng[i + 1].EntireRow) == 0)
                    {
                        rowsMarkedForDeletion.Add(i + 1);
                    }
                }
    
                for(int i = rowsMarkedForDeletion.Count - 1; i >= 0; i--)
                {                
                    rng[rowsMarkedForDeletion[i]].EntireRow.Delete();
                }
            }
