    public class BooContainer: IDataWithNameContainer<Boo>
    {
        IList<Boo> _list=new List<Boo>();
        public IList<Boo> DataList 
        { 
            get => _list; 
            set => _list=new List<Boo>(value); 
        }
    }
