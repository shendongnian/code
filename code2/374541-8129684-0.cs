    switch(Type.GetTypeCode(fi.FieldType)) {
        case TypeCode.Int16: bw.Write((Int16)fi.GetValue(obj)); break
        case TypeCode.UInt32: bw.Write((UInt16)fi.GetValue(obj)); break;
            ... etc lots and lots
    }
