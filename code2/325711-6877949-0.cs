    public class Geno<T> where T : Peno
    {
        private readonly T value;
        public Geno(T value)
        {
            this.value = value;
        }
    
        public string GetName()
        {
           return value.Name;
        }    
    }
