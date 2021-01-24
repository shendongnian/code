    public class Consumer
    {
        public void Call()
        {
            var param1 = new List<DataType1>();
            var t = new Common().Handler<DataType1>(param1).Result;
        }
    }
