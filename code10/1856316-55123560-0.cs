    public class Mroom {
        public int MroomId {get; set;}
        
        [ForeignKey("Move")]
        public int MoveId {get; set;}         //FK
        public virtual Move Move {get; set;}  //Navigation property 
                                              //configuration may be needed cf annotation
        [ForeignKey("Status")]        
        public int StatusId {get; set;}
        public virtual Status Status {get; set;}
        
        //... Mgroup, Guest, ...
    }
