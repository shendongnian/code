    public class FooData
    {
        public List<string> Strings { get; set; }
        public int MyInt { get; set; }
    }
    
    public FooData GetFooData(int id)
    {
        var fooStrings = _stringRepository.GetFooStrings(id); 
        //or wherever you're getting your data from
    
        return new FooData
                    {
                        Strings = fooStrings,
                        MyInt = id, //or whatever the int prop is supposed to be
                    };
    }
