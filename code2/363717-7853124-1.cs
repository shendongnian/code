    class ModelComparer : IEqualityComparer<Model>
    {
         public bool Equals(Model x, Model y)
         {
             // validations omitted
             return x.ID == y.ID;
         }
         public int GetHashCode(Model m)
         {
             return m.ID.GetHashCode();
         }
    }
