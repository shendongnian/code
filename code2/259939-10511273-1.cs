      #region private variables
      private String str1;
      private int iInt;
      private Double dblDouble;
      #endregion
      #region public variables
      [XmlAttribute("str", DataType = "string")]
      public String str
      {
        get { return str; }
      }
      [XmlElement("iInt")]
      public int iInt
      {
        get { return iInt;}
        set { iInt = value; }
      }
      [XmlElement("dblDouble")]
      public Double dblDouble
      {
        get { return dblDouble; }
        set { dblDouble = value; }
      }
      #endregion
      #region constructor
      public void InitilizeClassVars()
      {
      }
      public ClassElements()
      {
      InitilizeClassVars();
      #endregion
