            public class MyObject2
            {
                public MyObject2(int id, string name, string location, int parentId)
                {
                    this.Id = id;
                    this.Name = name;
                    this.Location = location;
                    this.ParentId = parentId;
                }
    
                public int Id
                {
                    get;
                    set;
                }
                public string Name
                {
                    get;
                    set;
                }
                public string Location
                {
                    get;
                    set;
                }
    
                public int ParentId
                {
                    get;
                    set;
                }
    
                public override string ToString()
                {
                    return String.Format ("Id={0}; Name={1}; Location={2}; ParentId={3}", Id, Name, Location, ParentId);
                }
            }
