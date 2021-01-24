    public class ThingList1 : AbstractThingList<string> { }
    
    public class ThingList2 : AbstractThingList<string> {
       private void SomeMethod() {
           this.Query<ThingList1>("query")
       }
    }
