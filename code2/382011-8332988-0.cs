        public class ObjectValue
        {
            public Decimal DecimalValue { get; set; }
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                var objectList = new List<ObjectValue>() { new ObjectValue() { DecimalValue = 5 }, new ObjectValue() { DecimalValue = 5 } ,
                        new ObjectValue() { DecimalValue = 5 }};
    
              
                var result = (objectList.Any()) ? objectList.Distinct().Sum(x => x.DecimalValue) : 0;
    
                decimal resultDecimal = 0;
                if (objectList.Any())
                    resultDecimal = objectList.Distinct().Sum(x => x.DecimalValue);
    
            }
        }
