      internal static MetaType GetMetaTypeFromDbType(DbType target) {
            // if we can't map it, we need to throw
            switch (target) {
            case DbType.AnsiString:             return MetaVarChar;
            case DbType.AnsiStringFixedLength:  return MetaChar;
            case DbType.Binary:                 return MetaVarBinary;
            case DbType.Byte:                   return MetaTinyInt;
            case DbType.Boolean:                return MetaBit;
            case DbType.Currency:               return MetaMoney;
            case DbType.Date:
            case DbType.DateTime:               return MetaDateTime;
            case DbType.Decimal:                return MetaDecimal;
            case DbType.Double:                 return MetaFloat;
            case DbType.Guid:                   return MetaUniqueId;
            case DbType.Int16:                  return MetaSmallInt;
            case DbType.Int32:                  return MetaInt;
            case DbType.Int64:                  return MetaBigInt;
            case DbType.Object:                 return MetaVariant;
            case DbType.Single:                 return MetaReal;
            case DbType.String:                 return MetaNVarChar;
            case DbType.StringFixedLength:      return MetaNChar;
            case DbType.Time:                   return MetaDateTime;
            case DbType.Xml:                    return MetaXml;
            case DbType.DateTime2:              return MetaDateTime2;
            case DbType.DateTimeOffset:         return MetaDateTimeOffset;
            case DbType.SByte:                  // unsupported
            case DbType.UInt16:
            case DbType.UInt32:
            case DbType.UInt64:
            case DbType.VarNumeric:
            default:                            throw ADP.DbTypeNotSupported(target, typeof(SqlDbType)); // no direct mapping, error out
            }
        }
