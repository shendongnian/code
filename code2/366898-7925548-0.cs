    interface IWithData
    {
        string GetData();
    }
    
    class Path: IWithData
    {
        public string GetData()
        {
            return "Tagore Path";
        }
    }
    
    class Road: IWithData
    {
        public string GetData()
        {
            return "Marlton Road";
        }
    }
    
    class SomeOtherClass
    {
        // ...
        public IWithData FETCH(bool flag)
        {
            if(flag)
            {
                Road obj=new Road();
                return obj;
            }
            else
            {
                Path obj=new Path();
                return obj;
            }
        }
        // ...
    }
    
