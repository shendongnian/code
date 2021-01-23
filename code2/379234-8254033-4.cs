    .Select(x =>
                {
                    object value;
                    if (x.GetValue(obj, null) == null) value = string.Empty;
                    else if (x.PropertyType.BaseType == typeof (Enum))
                        value = Convert.ToInt32(x.GetValue(obj, null));
                    else value = x.GetValue(obj, null);
                    return new
                                {
                                    Value = value,
                                    ((ReportAttribute)
                                    Attribute.GetCustomAttribute(x, typeof (ReportAttribute), false)).
                                        Order
                                };
                })
