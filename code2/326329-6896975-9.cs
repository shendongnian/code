        public class Manufacturer
        {
            public Manufacturer(int id, string name)
            {
                this.id = id;
                this.name = name;
            }
            public int id { get; set; }
            public string name { get; set; }
        }
        [Test]
        public void test222()
        {
            var L = new List<Manufacturer>() { new Manufacturer(1, "Abc"), new Manufacturer(2, "def"), new Manufacturer(3, "hij"), new Manufacturer(4, "klm"), new Manufacturer(5, "nop"), new Manufacturer(6, "qrs"), new Manufacturer(7, "tuv"), new Manufacturer(8, "wxyz") };
            var manufacturers = 
                new Manufacturer[] { new Manufacturer(-1, "[ALL]") }.AsEnumerable()
                .Union(from m in L select new Manufacturer(m.id, m.name)).Distinct().ToList();            
        }
