    public class Operator
    {
        public void Operate(ref List<IDated> objects)
        {
            objects = objects.Where(o => o.Date.HasValue).ToList();
            Console.WriteLine(String.Format("Objects in list = {0}\r\nOperation Succeeded: {1}", objects.Count(), objects.Count() == 1));
        }
    }
