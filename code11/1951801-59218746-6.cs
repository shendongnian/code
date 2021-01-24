        public class Location
        {
            private int ID;
            private string Name;
            public Location(int id, string name)
            {
                ID = id;
                Name = name;
            }
            public Tuple<int, string> GetById(int id)
            {
                if (id == this.ID)
                {
                    return new Tuple<int, string>(this.ID, this.Name);
                }
                else
                {
                    return new Tuple<int, string>(-1, "Not Found");
                }
            }
        }
