    public abstract class Element
        {
            public string ElementName { get; }
            public List<string> BadParameters { get; set; } = new List<string>();
    
            //Constructor
            public Element(string name)
            {
                ElementName = name;
            }
    
            /// <summary>
            /// Tjis Method is common for alal derived classes. Assuming content is same for all dervied class
            /// </summary>
            /// <returns></returns>
            //The method in question---
            public List<string> GetBadParameters()
            {
                return new List<string>() { "1", "2" };
            }
    
        }
