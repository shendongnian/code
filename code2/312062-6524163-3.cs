    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Globalization;
    namespace ConsoleApplication6
    {
        partial class Variant
        {
            public static Variant Create(object value)
            {
                var result = new Variant();
                if (value == null)
                    result.Type = VariantType.NULL;
                else if (value is string)
                    result.ValueString = (string)value;
                else if (value is byte[])
                    result.ValueBytes = (byte[])value;
                else if (value is bool)
                    result.Type = (bool)value ? VariantType.BOOLTRUE : VariantType.BOOLFALSE;
                else if (value is float)
                {
                    if ((float)value == 0f)
                        result.Type = VariantType.FLOATZERO;
                    else
                        result.ValueFloat = (float)value;
                }
                else if (value is double)
                {
                    if ((double)value == 0d)
                        result.Type = VariantType.DOUBLEZERO;
                    else
                        result.ValueDouble = (double)value;
                }
                else if (value is decimal)
                    result.ValueDecimal = ((decimal)value).ToString("r", CultureInfo.InvariantCulture);
                else if (value is DateTime)
                    result.ValueDatetime = ((DateTime)value).ToString("o", CultureInfo.InvariantCulture);
                else
                    throw new ArgumentException(String.Format("Cannot store data type {0} in Variant", value.GetType().FullName), "value");
                return result;
            }
            public object Value
            {
                get
                {
                    switch (Type)
                    {
                        case VariantType.BOOLFALSE:
                            return false;
                        case VariantType.BOOLTRUE:
                            return true;
                        case VariantType.NULL:
                            return null;
                        case VariantType.DOUBLEZERO:
                            return 0d;
                        case VariantType.FLOATZERO:
                            return 0f;
                        case VariantType.INT32ZERO:
                            return 0;
                        case VariantType.INT64ZERO:
                            return (long)0;
                        default:
                            if (ValueInt32 != 0)
                                return ValueInt32;
                            if (ValueInt64 != 0)
                                return ValueInt64;
                            if (ValueFloat != 0f)
                                return ValueFloat;
                            if (ValueDouble != 0d)
                                return ValueDouble;
                            if (ValueString != null)
                                return ValueString;
                            if (ValueBytes != null)
                                return ValueBytes;
                            if (ValueDecimal != null)
                                return Decimal.Parse(ValueDecimal, CultureInfo.InvariantCulture);
                            if (ValueDatetime != null)
                                return DateTime.Parse(ValueDatetime, CultureInfo.InvariantCulture);
                            return null;
                    }
                }
            }
        }
    }
