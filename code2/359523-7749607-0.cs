    public class Character
    {
        public Character()
        {
            ...
        }
        #region Abilities
        ...
        #endregion
        public Func<int> Strength
        {
            get { return () => Str.Score; }
            set { Str.Score = value(); }
        }
    }
