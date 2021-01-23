    public Observablecollection<int> foo = new ObservableCollection<int>()
    
    private void Calculation(int[] X, int[] Y)
    {
        foo.Clear();
        int i;
        for(int index = 0; index < X.Length; index++)
        {
            //Calculation Like
            i = X[index] + y[index];
            foo.Add(i);
        }
    }
