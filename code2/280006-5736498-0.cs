    public IEnumerable<L> GenerateLs(int rows, int columns)
    {
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                yield return new L(row, column);
            }
        }
    }
    
    gList.Add(l => GenerateLs(rows,columns).Select(new G(this,l,0,20,30)));
