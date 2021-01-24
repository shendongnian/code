        case MySqlDbType.Set:
        case MySqlDbType.Enum:
        case MySqlDbType.String:
        case MySqlDbType.VarString:
        case MySqlDbType.VarChar:
        case MySqlDbType.Text:
        case MySqlDbType.TinyText:
        case MySqlDbType.MediumText:
        case MySqlDbType.LongText:
        case MySqlDbType.JSON:
        case (MySqlDbType)Field_Type.NULL:
          return new MySqlString(type, true);
