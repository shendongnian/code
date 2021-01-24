    public class Type
    {
    public string Name { private set; get } ;
    public string NameTag {private set; get };
        public TypeList(string Name, string NameTag)
        {
            this.Name = Name;
            this.NameTag = NameTag;
        }
    
    }
    //use in the class of main, the form or some similar central point
    static List<Type> TypeList = new List<Type>();
