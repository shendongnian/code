    public class LookupMap : ClassMap<Lookup> {
        public LookupMap(){
            Id(x=>x.Id).GeneratedBy.Assigned(); //Needs to be a unique ID
            Map(x=>x.Tablename);
            Map(x=>x.ColumnName);
            Map(x=>x.Description);
            //Business Info property mappings here
            Table("LookupView")
            DiscriminateSubClassesOnColumn<string>("ColumnName");
            ReadOnly();
        }
    }
    public class ArmourLookupMap : SubClassMap<ArmourLookup> {
        public ArmourLookupMap (){
            DiscriminatorValue("ArmourColumn");
        }
    }
