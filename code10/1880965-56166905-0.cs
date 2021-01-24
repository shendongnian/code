    public class AggregateCalculator : IVariantProcessor
    {
        private string _myAppConnectionString { get; set; }
         public void Process(Variant model)
         {
                _myAppConnectionString = ConfigurationManager.ConnectionStrings["dbConnectionString"].ConnectionString;
                new VariantProcessor( _myAppConnectionString,
                   (o) => Transform(model)
                   );
         }
        private void Transform(Variant model)
        {
            //logic on variant model
        }
    }
