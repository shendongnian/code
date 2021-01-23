    public class TableInfo {
         public virtual int Id {get; set;} 
         public virtual string Tablename {get; set;}
         public IList<ColumnInfo> Columns {get; set;}
    }
    public class ColumnInfo {
       public virtual int Id {get; set;}
       public virtual TableInfo TableInfo {get; set;}
       public virtual BusinessInfo BusinessInfo {get; set;}
       public virtual LookupDescriptionInfo LookupDescriptionInfo {get; set;}
       //Other properties
    }
    public class ArmourInfoColumn : ColumnInfo {
        //In the mapping you would discriminate on the columnname column.
    }
    etc...
