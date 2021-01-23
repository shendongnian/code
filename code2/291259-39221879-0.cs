     public static void WriteValueOnCell(Cell cell, object value)
        {
            var sValue = value = x.ToString();
            var isValueNumeric = value.GetType().IsNumeric();
            cell.DataType = (isValueNumeric)? CellValues.Number : CellValues.String;
            cell.CellValue = new CellValue(sValue);
        }
        //This example uses this Helper. It informs if an object type is Numeric ;-)
        public static class TypeHelper
        {
            private static readonly HashSet<Type> NumericTypes = new HashSet<Type>
            {
                typeof(int),  typeof(double),  typeof(decimal),
                typeof(long), typeof(short),   typeof(sbyte),
                typeof(byte), typeof(ulong),   typeof(ushort),
                typeof(uint), typeof(float)
            };
    
            public static bool IsNumeric(this Type myType)
            {
                return NumericTypes.Contains(Nullable.GetUnderlyingType(myType) ?? myType);
            }
        }
