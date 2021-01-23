    public IEnumerable<TResult> Select(IEnumerable<string> result)
        {
            return result.Select(r=>
                {
                    TResult item = null;
                    TResult.TryParse(r, item);
                    return item;
                }).Where(item=>item != null);
        }
