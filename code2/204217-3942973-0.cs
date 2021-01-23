    [DelimitedRecord(",") ]
    [IgnoreFirst(1)] 
    public class Product
    :INotifyRead
    {
        public int? ID;
        public string Description;
    
        [FieldConverter(ConverterKind.Decimal)]
        public decimal? Val;
    
        private static Product Previuous;
    
        public void AfterRead(EngineBase engine, string line)
        {
            if (!ID.HasValue && Previous != null)
                  this.ID = Previus.ID;
    
            if (!Val.HasValue && Previous != null)
                  this.Val= Previus.Val;
    
            Previuous = this;
        }
    }
