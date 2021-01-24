    public class Logic
    {
        public MyObject Object001, Object002, ... Object200;
        public Logic()
        {
            // Create the value to set all fields to.
            MyObject valueToInstantiate = new MyObject();
            // Set all fields to that value.
            this.InstantiateAllObjects(valueToInstantiate);
        }
    }
