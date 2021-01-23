    private void SetFirstNotNullOrEmpty(string first, string second, Action<T> setter)
    {
        if (String.IsNullOrEmpty(first))
        {
            setter(second);
        }
    }
