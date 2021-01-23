    namespace Project
    {
        public class PricesConfiguration : System.Configuration.ConfigurationSection
        {
            public static PricesConfiguration GetConfig()
            {
                 return (PricesConfiguration )System.Configuration.ConfigurationManager.GetSection("pricesConfiguration") ?? new ShiConfiguration();
            }
            [System.Configuration.ConfigurationProperty("prices")]
            public PricesCollection Prices
            {
               get
               {
                  return (PricesCollection)this["prices"] ?? 
                    new PricesCollection();
			 }
		  }
	   }
	   
	   public class PricesCollection : System.Configuration.ConfigurationElementCollection
	   {
		  public PriceElement this[int index]
		  {
			 get
			 {
				return base.BaseGet(index) as PriceElement;
			 }
			 set
			 {
				if (base.BaseGet(index) != null)
				   base.BaseRemoveAt(index);
				this.BaseAdd(index, value);
			 }
		  }
		  
		  protected override System.Configuration.ConfigurationElement CreateNewElement()
		  {
			 return new PriceElement();
		  }
		  protected override object GetElementKey(System.Configuration.ConfigurationElement element)
		  {
			 var price = (PriceElement)element;
			 return string.Format("{0}-{1}->{2}%",price.Start,price.End,price.Percentage);
		  }
		}
		public class PriceElement : System.Configuration.ConfigurationElement
		{
			[System.Configuration.ConfigurationProperty("start", IsRequired = false)]
			public int? Start
			{
				get
				{
					return this["start"] as int?;
				 }
			}
			[System.Configuration.ConfigurationProperty("end", IsRequired = false)]
			public int? End
			{
				get
				{
					return this["end"] as int?;
				}
			}
			[System.Configuration.ConfigurationProperty("percentage", IsRequired = true)]
			public string Percentage
			{
				get
				{ 
					return this["percentage"] as string;
				}
			}
		}
	}
