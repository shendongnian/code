    internal decimal Decimal
    {
        get
        {
            ThrowIfNull();
            if (StorageType.Decimal == _type)
            {
                if (_value._numericInfo.data4 != 0 || _value._numericInfo.scale > 28)
                {
                    throw new OverflowException(SQLResource.ConversionOverflowMessage);
                }
                return new decimal(_value._numericInfo.data1, _value._numericInfo.data2, _value._numericInfo.data3, !_value._numericInfo.positive, _value._numericInfo.scale);
            }
            if (StorageType.Money == _type)
            {
                long l = _value._int64;
                bool isNegative = false;
                if (l < 0)
                {
                    isNegative = true;
                    l = -l;
                }
                return new decimal((int)(l & 0xffffffff), (int)(l >> 32), 0, isNegative, 4);
            }
            return (decimal)this.Value; // anything else we haven't thought of goes through boxing.
        }
    }
