    public static implicit operator Decimal(byte value)
    {
       return new Decimal(value);
    }
    
    [CLSCompliant(false)]
    public static implicit operator Decimal(sbyte value)
    {
       return new Decimal(value);
    }
    
    public static implicit operator Decimal(short value)
    {
       return new Decimal(value);
    }
    
    [CLSCompliant(false)]
    public static implicit operator Decimal(ushort value)
    {
       return new Decimal(value);
    }
    
    public static implicit operator Decimal(char value)
    {
       return new Decimal(value);
    }
    
    public static implicit operator Decimal(int value)
    {
       return new Decimal(value);
    }
    
    [CLSCompliant(false)]
    public static implicit operator Decimal(uint value)
    {
       return new Decimal(value);
    }
    
    public static implicit operator Decimal(long value)
    {
       return new Decimal(value);
    }
    
    [CLSCompliant(false)]
    public static implicit operator Decimal(ulong value)
    {
       return new Decimal(value);
    }
    
    
    public static explicit operator Decimal(float value)
    {
       return new Decimal(value);
    }
    
    public static explicit operator Decimal(double value)
    {
       return new Decimal(value);
    }
    
    public static explicit operator byte(Decimal value)
    {
       return ToByte(value);
    }
    
    [CLSCompliant(false)]
    public static explicit operator sbyte(Decimal value)
    {
       return ToSByte(value);
    }
    
    public static explicit operator char(Decimal value)
    {
       UInt16 temp;
       try
       {
          temp = ToUInt16(value);
       }
       catch (OverflowException e)
       {
          throw new OverflowException(Environment.GetResourceString("Overflow_Char"), e);
       }
       return (char)temp;
    }
    
    public static explicit operator short(Decimal value)
    {
       return ToInt16(value);
    }
    
    [CLSCompliant(false)]
    public static explicit operator ushort(Decimal value)
    {
       return ToUInt16(value);
    }
    
    public static explicit operator int(Decimal value)
    {
       return ToInt32(value);
    }
    
    [CLSCompliant(false)]
    public static explicit operator uint(Decimal value)
    {
       return ToUInt32(value);
    }
    
    public static explicit operator long(Decimal value)
    {
       return ToInt64(value);
    }
    
    [CLSCompliant(false)]
    public static explicit operator ulong(Decimal value)
    {
       return ToUInt64(value);
    }
    
    public static explicit operator float(Decimal value)
    {
       return ToSingle(value);
    }
    
    public static explicit operator double(Decimal value)
    {
       return ToDouble(value);
    }
    
    public static Decimal operator +(Decimal d)
    {
       return d;
    }
    
    public static Decimal operator -(Decimal d)
    {
       return Negate(d);
    }
    
    public static Decimal operator ++(Decimal d)
    {
       return Add(d, One);
    }
    
    public static Decimal operator --(Decimal d)
    {
       return Subtract(d, One);
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static Decimal operator +(Decimal d1, Decimal d2)
    {
       FCallAddSub(ref d1, ref d2, DECIMAL_ADD);
       return d1;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static Decimal operator -(Decimal d1, Decimal d2)
    {
       FCallAddSub(ref d1, ref d2, DECIMAL_NEG);
       return d1;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static Decimal operator *(Decimal d1, Decimal d2)
    {
       FCallMultiply(ref d1, ref d2);
       return d1;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static Decimal operator /(Decimal d1, Decimal d2)
    {
       FCallDivide(ref d1, ref d2);
       return d1;
    }
    
    public static Decimal operator %(Decimal d1, Decimal d2)
    {
       return Remainder(d1, d2);
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static bool operator ==(Decimal d1, Decimal d2)
    {
       return FCallCompare(ref d1, ref d2) == 0;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static bool operator !=(Decimal d1, Decimal d2)
    {
       return FCallCompare(ref d1, ref d2) != 0;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static bool operator <(Decimal d1, Decimal d2)
    {
       return FCallCompare(ref d1, ref d2) < 0;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static bool operator <=(Decimal d1, Decimal d2)
    {
       return FCallCompare(ref d1, ref d2) <= 0;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static bool operator >(Decimal d1, Decimal d2)
    {
       return FCallCompare(ref d1, ref d2) > 0;
    }
    
    [System.Security.SecuritySafeCritical]  // auto-generated
    public static bool operator >=(Decimal d1, Decimal d2)
    {
       return FCallCompare(ref d1, ref d2) >= 0;
    }
 
