    void MoveToNext() {
        if (Enumerator != null)
        {
            if (Enumerator.MoveNext()) Browser.Navigate(Enumerator.Current);
            else {
                Enumerator.Dispose();
                Enumerator = null;
            }
        }
    }
