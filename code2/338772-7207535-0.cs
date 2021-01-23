    public class AMap : ClassMap<A>
    {    
        Public AMap()
        { 
           // ...
           HasMany(x => x.Cs).Table("A_C").KeyColumn("TheNameOfA'sPrimaryKeyColumn"); 
        }  
    }
    
    public class BMap : ClassMap<B>
    {    
        Public BMap()
        { 
           // ...
           HasMany(x => x.Cs).Table("B_C").KeyColumn("TheNameOfB'sPrimaryKeyColumn"); 
        }  
    }
