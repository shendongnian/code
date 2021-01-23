    public class GroupBase<OptionType> 
        where OptionType: OptionBase
    {
        public string Name { set; get; }
        public string Type { set; get; }
        public List<OptionType> Options { set; get; }
    
        public GroupBase(string name, string type, 
            Func<object, OptionType> optionTypeFactory)
        {
             this.Name = name;
             this.Type = type;
    
             DataSet ds = DatabaseRetreival(this.Type);
             this.Options.Add(optionTypeFactory(ds["Name"]));
        }
    }
