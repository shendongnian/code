    public class Operator
    {
        public void Operate(IEnumerable<IDated> objects)
        {
            objects = from o in objects where o.Date.HasValue select o;
        }
    }
