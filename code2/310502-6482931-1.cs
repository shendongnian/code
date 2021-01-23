        foreach (object value in values)
        {
            if (value is char)
            { 
                dataStream.Write((char) value);
            }
            else if (value is byte)
            {
                dataStream.Write((byte) value);
            }
            else if (value is int)
            {
                dataStream.Write((int) value);
            }
            else
            {
                throw new ArgumentException("Unsupported type in input data");
            }
        }
