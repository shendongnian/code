    public class Move
    {
        private int power;
        private float accuracy;
        private string type; 
        private string style;  
        public Move(int p, float a, string t, string s, float sh)
        {
            power = p;
            accuracy = a;
            type = t;
            style = s;
            // a static class member is simply accessed via the type itself
            MoveManager.Moves.Add(this);
        }
    }
