    class class1 : Interface1, Interface2
    {
        #region Interface1 Members
       
        public string method2()
        {
            return (this as Interface2).method22();
        }      
        #endregion
        #region Interface2 Members      
        string Interface2.method22()
        {
            return "2";
        }
      
        #endregion
    }
