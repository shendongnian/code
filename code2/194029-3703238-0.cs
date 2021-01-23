    static int arrayRows = 20;
    static int arrayCols = 20;
    public void printBoard()
    {
        var sequences = from row in Enumerable.Range(0, arrayRows)
                        from column in Enumerable.Range(0, arrayCols)
                        select new
                        {
                            Rows = (from xs in new[] { row - 1, row, row + 1 }
                                    where xs >= 0 && xs < 20
                                    select xs),
                            Columns = (from ys in new[] { column - 1, column, column + 1 }
                                       where ys >= 0 && ys < 20
                                       select ys)
                        };
        //now that we have a sequence with all the needed (valid) indices 
        //iterate through the combinations of those
        var neighbours = (from seq in sequences
                          from row in seq.Rows
                          from column in seq.Columns
                          where row != column && parentGen[row, column] == 1
                          select 1).Count();
    }
