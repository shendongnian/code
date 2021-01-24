    public class Group
    {
        public Position[] Positions { get; private set; }
        public void ShiftRight()
        {
            Array.Copy(Positions,0,Positions,1,Positions.Length-1);//Right
            Positions[0].Tile=null;
            Array.Copy(g,1,g,0,g.Length-1);
        }
        public void ShiftLeft()
        { 
            Array.Copy(Positions,1,Positions,0,Positions.Length-1)
            Positions[Positions.Length-1].Tile=null;
        }
    }
    public class Position
    {
        // [other properties]
        public Tile Tile { get; set; }
    }
