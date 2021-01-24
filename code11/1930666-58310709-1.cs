    class MyComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            string[] xParts = x.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            string[] yParts = y.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0;;i++)
            {
                if (xParts.Length >= i && yParts.Length < i)
                    return 1;
                if (xParts.Length < i && yParts.Length >= i)
                    return -1;
                if (xParts.Length < i && yParts.Length < i)
                    return 0;
                int compared = int.Parse(xParts[i]).CompareTo(int.Parse(yParts[i]));
                if (compared != 0)
                    return compared;
            }
        }
    }
