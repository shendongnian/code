    public class Foo<T> where T : new()
    {
        public IEnumerable<T> Handler(IEnumerable<T> items)
        {
            var list = new List<T>();
            foreach (var item in items)
            {
                list.Add(new T
                {
                    ID = item.ID,
                    Name = item.Status,
                    Retrieved = DateTime.Now,
                });
            }
            return list;
        }
    }
