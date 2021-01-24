    public class Field
    {
        GameStateModel GameState { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        private Ship ShipOnField
        {
            get
            {
                return GameState.Ships.Where(s => s.Row == Row && s.Col == Col).FirstOrDefault();
            }
        }
        public bool HasShip
        {
            get
            {
                return ShipOnField != null;
            }
        }
        public bool IsShipSunk
        {
            get
            {
                return ShipOnField != null && ShipOnField.Ded;
            }
        }
    }
