    foreach (var x in asm.GetTypes())
    {
       if (x.Name=="Data")
       {
           var attr = x.GetCustomAttributes(false)[0]; // if you know that the type has only 1 attribute
           var a = attr.GetType().GetProperty("A").GetValue(attr, null);
           var b = attr.GetType().GetProperty("B").GetValue(attr, null);
        }
    }
