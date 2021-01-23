    public IEnumerable<T> this[int x]
    {
        get 
        {
              for(int y=0; y<matrix.Count; y++)
                    yield return matrix[y][x];            
        }
    }
