    public class User {
         
         private UserTickList<Tick> _userTicks = new UserTickList<Tick>();
         public void AddUserTick(Tick t) {
                  _userTicks.Add(t);
         }
         /*remove, update if need*/
    }
     public class UserTickList {
        
        private List<Tick> _list = new List<Tick>();
        public void AddTick(Tick tick) {
             if(_list.Count == 10){
                   /*perform what you need*/
             }
             else 
               _list.Add(tick);
        }
     }
