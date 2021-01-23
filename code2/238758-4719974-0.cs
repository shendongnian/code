    SortedDictionary<DateTime, float[]> Pages = new SortedDictionary<DateTime,float[]>();
    DateTime date = DateTime.UtcNow;
    float[] arr = Pages[date];
    Array.Resize<float>(ref arr, arr.Length + 1);
    Pages[date] = arr; // [] overwrites the old value, unlike Add().
