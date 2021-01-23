    public static void SetValue<T>(T value)
        {
            switch (Type.GetTypeCode(typeof(T)))
            {
                #region These types are not what u want, comment them to throw ArgumentOutOfRangeException
    
                case TypeCode.Empty:
                    break;
                case TypeCode.Object:
                    break;
                case TypeCode.DBNull:
    
                    #endregion
    
                    break;
                case TypeCode.Boolean:
                    break;
                case TypeCode.Char:
                    break;
                case TypeCode.SByte:
                    break;
                case TypeCode.Byte:
                    break;
                case TypeCode.Int16:
                    break;
                case TypeCode.UInt16:
                    break;
                case TypeCode.Int32:
                    break;
                case TypeCode.UInt32:
                    break;
                case TypeCode.Int64:
                    break;
                case TypeCode.UInt64:
                    break;
                case TypeCode.Single:
                    break;
                case TypeCode.Double:
                    break;
                case TypeCode.Decimal:
                    break;
                case TypeCode.DateTime:
                    break;
                case TypeCode.String:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
