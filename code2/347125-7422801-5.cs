    class DrinkerDoses {
      DrinkDoses doses;
      [DisplayName("Doses")]
      [Description("Drinker doses")]
      [Category("Alcoholics drinking")]
      [TypeConverter(typeof(DrinkDosesConverter))]
      public DrinkDoses Doses {
        get { return doses; }
        set { doses = value; }
      }
      int dataInt; 
      public int DataInt {
        get { return dataInt; }
        set { dataInt = value; }
      }
    }
