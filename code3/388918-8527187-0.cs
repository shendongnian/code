    public class Class1 
    {
        enum Player
        {
            Me,
            Opponent
        }    
    
        List<MovesMade> AllMoves = new List<MovesMade> {};
    
        public void MyFunc() 
        {
            MovesMade movesMade = new MovesMade();
            movesMade.Peep = Player.Me;
            AlllMoves.Add(movesMade);
    
            if (movesMade.Peep == Player.Me) {
    
            } 
        }
    }
    
    public class MovesMade
    {
        public MovesMade(){
           
        }
        public Player Peep { get; set; }
        //Other properties here
    }
