    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace WpfApp1
    {
        public class Container : IEnumerable<Container>
        {
            public string Text { get; set; }
    
            public List<Container> Root { get; private set; } = new List<Container>();
    
            public List<Container> Hard { get; } = new List<Container>();
    
            public List<Container> Soft { get; } = new List<Container>();
    
            public IEnumerator<Container> GetEnumerator()
            {
                var list = new List<Container>();
    
                foreach (var item in Root)
                {
                    list.Add(item);
                }
    
                if (Soft.Any())
                {
                    list.Add(new Container {Text = nameof(Soft), Root = Soft});
                }
    
                if (Hard.Any())
                {
                    list.Add(new Container {Text = nameof(Hard), Root = Hard});
                }
    
                return list.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public override string ToString()
            {
                return Text;
            }
        }
    }
