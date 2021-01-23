    public static class CustomObjExtensions
    {
        public static CustomObj Get(this CustomObj[] Array, string Name)
        {
            Array.Where(x => x.Name == Name).FirstOrDefault();
        }
    }
