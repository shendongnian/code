    public void Add(IEnumerable<T> row)
    {
        // here we ought to check that the list has the right number of elements
        if(matrix.Count == 0 || row.Count == matrix.Last().Count)
        {
            martrix.Add(row.ToList());
        }
        else
        {
            throw new 
                ArgumentException("row", 
                    "new row contains the wrong number of elements")
        }
    }
