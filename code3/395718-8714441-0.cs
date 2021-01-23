    public static List<List<T>> GetVariations<T>(int k, List<T> elements)
    {
        List<List<T>> result = new List<List<T>>();
        if (k == 1)
        {
            result.AddRange(elements.Select(element => new List<T>() { element }));
        }
        else
        {
            foreach (T element in elements)
            {
                List<T> subelements = elements.Where(e => !e.Equals(element)).ToList();
                List<List<T>> subvariations = GetVariations(k - 1, subelements);
                foreach (List<T> subvariation in subvariations)
                {
                    subvariation.Add(element);
                    result.Add(subvariation);
                }
            }
         }
         return result;
     }
