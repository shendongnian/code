        public class MyPropertyConvention : IPropertyConvention
        {
            public void Apply( IPropertyInstance instance )
            {
                instance.Column( instance.Name ); //this call is destructive
                                                  //to ColumnPrefix() in FNH v1.2
            }
        }
