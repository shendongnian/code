    [Serializable]
    public class Prototype
    {
        public virtual long Id { get; private set; }
        public virtual string Name { get; set; }   
        [XMLIgnore]
        public virtual IList<AttributeGroup> AttributeGroups { 
            get { return this.AttributeGroupsList; } 
        }
        public virtual List<AttributeGroup> AttributeGroupsList { get; private set;}
    }
