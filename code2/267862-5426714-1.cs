    public class DecimalConvention : IPropertyConvention
        {
            public void Apply(IPropertyInstance instance)
            {
                if (instance.Type == typeof(decimal) || instance.Name == "Value") //Set the condition based on your needs
                {
                   instance.Precision(22).Scale(12);    
                }
            }
        }
