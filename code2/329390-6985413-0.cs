    public Class ClassAMap : ClassMap<ClassA>{
        public ClassAMap(){
           Id(x => x.Id);
           References(x => x.ObjAC, "TableC_ID").Cascade.All();
           ...
        }
     }
    
     public Class ClassBMap : ClassMap<ClassB>{
        public ClassBMap(){
           Id(x => x.Id);
           HasOne(x => x.ObjBC, "TableC_ID").Cascade.All();
           ...
        }
     }
    
     public Class ClassCMap : ClassMap<ClassC>{
        public ClassCMap(){
           Id(x => x.Id);
        }
     }
