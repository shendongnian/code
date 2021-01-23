    public class Human
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }
    public class HumanMap : ClassMap<Human>
    {
        public HumanMap()
        {
            this.Id(x => x.ID).CustomSqlType("Serial").GeneratedBy.Native();
            this.Map(x => x.Name);
        }
    }
