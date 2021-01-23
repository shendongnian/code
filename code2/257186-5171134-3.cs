    interface IMyInterface{
        int val1 {get;}
        string val2 {get;}
        IList<int>val3 {get;}
    }
    public IMyInterface showMe
        {
            get
            {
                return new
                {
                    val1 = 5,
                    val2 = "This is val2",
                    val3 = new List<int>(){1,2,3,4,5}
                }.ActLike<IMyInterface>();
            }
        }
