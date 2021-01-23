    class DTONaming : INamingConvention
    {
        #region INamingConvention Members
        public string SeparatorCharacter
        {
            get { return string.Empty; }
        }
        public Regex SplittingExpression
        {
            get { return new Regex(""); }
        }
        #endregion
    }
