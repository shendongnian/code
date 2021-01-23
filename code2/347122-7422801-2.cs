    class DrinkerDoses {
      DrinkDoses m_doses;
      [DisplayName("Doses")]
      [Description("Drinker doses")]
      [Category("Alcoholics drinking")]
      [TypeConverter(typeof(DrinkDosesConverter))]
      public DrinkDoses Doses {
        get { return m_doses; }
        set { m_doses = value; }
      }
      int m_dataInt; 
      public int DataInt {
        get { return m_dataInt; }
        set { m_dataInt = value; }
      }
    }
