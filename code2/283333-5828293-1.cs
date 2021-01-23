        public interface IAttribute {
            string Identity { get; set; }
            string Name { get; set; }
            T GetValue<T>();
        }
    
        public class Attribute<T> : IAttribute
        {
    
            public string Identity { get; set; }
            public string Name { get; set; }
            public T Value { get; set; }
            public Tret GetValue<Tret>() {
                return (Tret)Convert.ChangeType(Value, typeof(T));
            }
        }
    
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                List<IAttribute> lst = new List<IAttribute>();
                Attribute<string> attr1 = new Attribute<string>();
                attr1.Value = "test";
    
                Attribute<int> attr2 = new Attribute<int>();
                attr2.Value = 2;
    
                lst.Add(attr1);
                lst.Add(attr2);
    
                string attr1val = lst[0].GetValue<string>();
                int attr2val = lst[1].GetValue<int>();
    
            }
        }
