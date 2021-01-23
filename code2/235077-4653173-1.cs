    public static class AbstractPackageCallHelper
    {
        public static List<U> Select(this List<T> source)
            where T : AbstractPackageCall
            where U : T
        {
            List<U> target = new List<U>();
            foreach(var element in source)
            {
                if (element is U)
                {
                     target.Add((U)element);
                }
            }
            return target;
        }
    }
