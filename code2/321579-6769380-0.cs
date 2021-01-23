        public void WriteList<T>(List<T> value)
        {
            for (int i = 0; i < value.Count; i++)
            {
                switch (Type.GetTypeCode(typeof(T))){
                //_writer.Write(value[i]);
                    case TypeCode.Boolean:
                        _writer.Write((bool)(object)value[i]);
                        break;
                    case TypeCode.Byte:
                        _writer.Write((byte)(object)value[i]);
                        break;
                    case TypeCode.Char:
                        _writer.Write((char)(object)value[i]);
                        break;
                    case TypeCode.Decimal:
                        _writer.Write((decimal)(object)value[i]);
                        break;
                    case TypeCode.Double:
                        _writer.Write((double)(object)value[i]);
                        break;
                    case TypeCode.Single:
                        _writer.Write((float)(object)value[i]);
                        break;
                    case TypeCode.Int16:
                        _writer.Write((short)(object)value[i]);
                        break;
                    case TypeCode.Int32:
                        _writer.Write((int)(object)value[i]);
                        break;
                    case TypeCode.Int64:
                        _writer.Write((short)(object)value[i]);
                        break;
                    case TypeCode.String:
                        _writer.Write((string)(object)value[i]);
                        break;
                    case TypeCode.SByte:
                        _writer.Write((sbyte)(object)value[i]);
                        break;
                    case TypeCode.UInt16:
                        _writer.Write((ushort)(object)value[i]);
                        break;
                    case TypeCode.UInt32:
                        _writer.Write((uint)(object)value[i]);
                        break;
                    case TypeCode.UInt64:
                        _writer.Write((ulong)(object)value[i]);
                        break;
                    default:
                        if (typeof(T) == typeof(byte[]))
                        {
                            _writer.Write((byte[])(object)value[i]);
                        }
                        else if (typeof(T) == typeof(char[]))
                        {
                            _writer.Write((char[])(object)value[i]);
                        }
                        else
                        {
                            throw new ArgumentException("List type not supported");
                        }
                        break;
                }
            }
