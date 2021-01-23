            for (int r = 1; r <= rng.Tables[1].Row.Count; r++)
            {
                for (int c = 1; c <= rng.Tables[1].Columns.Count; c++)
                {
                    try
                    {
                        Cell cell = table.Cell(r, c);
                        //Do what you want here with the cell
                    }
                    catch (Exception e)
                    {
                        if (e.Message.Contains("The requested member of the collection does not exist."))
                        {
                           //Most likely a part of a merged cell, so skip over.
                        }
                        else throw;
                    }
                }
            }
