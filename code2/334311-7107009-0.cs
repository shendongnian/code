    public class A
    {
        ...
        public List<B> Bs { get; private set; }
 
        [AdditionalInit]
        public void OnInit(IDataStore dstore)
        {
            Bs = dstore.Query<B>().Where(b => b.A.Id == Id).ToList();
        }
    }
