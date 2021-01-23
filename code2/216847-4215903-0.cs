    public class MyClass
    {
        private string _eventData;
        private void setup(string someData) 
        {
           _eventData = someData;
           Object.assignHandler(evHandler);
        }
        public void evHandler()
        {
            // do something with _eventData here
        }
    }
