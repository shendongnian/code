      static void CopyProperties(object dest, object src)
      {
       foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(src))
       {
        item.SetValue(dest, item.GetValue(src));
       } 
      }
