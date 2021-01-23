    case EsfValueType.Binary4E: //System.String[]
    {
        int size = (int)(this.reader.ReadUInt32() - ((uint)this.reader.BaseStream.Position));
        var strings = new StringBuilder();
        for (int i = 0; i < size / 4; i++)
        {
            strings.Append(this.stringValuesUTF16[this.reader.ReadUInt32()]); //or AppendLine, depending on what you need
        }
        esfValue.Value = strings.ToString();
        break;
    }
