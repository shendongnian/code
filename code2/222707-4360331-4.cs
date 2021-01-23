    public class Foo
    {
        public string myProperty = "foobar";
        public Task t;
    
        public Foo()
        {
            t = Task.Factory.StartNew(() =>
            {
                myProperty = "test";
    
            });
        }
    
        //THIS won't compile
        //public Task t = Task.Factory.StartNew(() =>
        //{
        //    myProperty = "test";
    
        //});
    
        public Task GetTask()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                myProperty = "test";
    
            });
            return t;
        }
    }
