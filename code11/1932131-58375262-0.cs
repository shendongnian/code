    public class DecimalTypeHandler : 
    
        SqlMapper.TypeHandler<Sap.Data.Hana.HanaDecimal>
        {
            public override decimal Parse(object value)
            {
                return Convert.ToDecimal(value);
            }
        
            public override void SetValue(IDbDataParameter parameter, decimal value)
            {
                parameter.Value = value;
            }
        }
