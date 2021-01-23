    var arrayUpdated = new string[a.GetUpperBound(1)][a.GetUpperBound(0)-1];
    for (int n = index; n < a.GetUpperBound(1); n++)
    {
         for (int i = 0; i < a.GetUpperBound(0); i++)
         {
             arrayUpdated [i, n] = a[i, 1];
         }
    }
