    [AttributeUsage(AttributeTargets.Method)]
      sealed class AttributesTest : Attribute 
      {
        public string sName;
        public string sDescription;
    
        public string Name
        {
          get { return sName; }
          set { sName = value; }
        }
    
        public string Description
        {
          get { return sDescription; }
          set { sDescription = value; }
        }
    
        public AttributesTest(string _name, string _desc)
        {
          this.Name = _name;
          this.Description = _desc;
        }
      }
