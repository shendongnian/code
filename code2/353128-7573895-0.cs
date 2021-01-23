public class Repository {
        private ABEntities entities = new ABEntities();
        public IList&lt;A&gt; FindAllA(string b_prop)
        {
            return (from b in entities.Bs
                   where b.B_prop == b_prop
                   select b.Ayes).ToList();
        }
    }
