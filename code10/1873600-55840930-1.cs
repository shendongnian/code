    public class ModelEqualityComparer : IEqualityComparer<Model>
    {
        public bool Equals(Model x, Model y)
        {
            return x.Id == y.Id && x.Name == y.Name && x.Age == y.Age;
        }
    
        ...
    }
