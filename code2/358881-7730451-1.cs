    public IEnumerable<int> GetListOfIds(string ids)
    {
        foreach (string part in ids.Split(','))
        {
            int x;
            if (!int.TryParse(part, out x))
            {
                throw new ArgumentException(
                    string.Format("The value {0} cannot be parsed as an integer.", part),
                    "ids");
            }
            else
            {
                yield return x;
            }
        }
    }
