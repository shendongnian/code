    [Serializable]
    public class Foo
    {
    private Bar _bar;
    
        public int BarID
        {
            get { return _bar.Id;}
            set 
            {
                 if (_bar==null) _bar= new Bar();
     
                 _bar.Id = id;
           }
        }
    
    }
