       Type itemType = typeof (object);
       if(list.GetType().GetGenericArguments().Length>0)
       {
           itemType = list.GetType().GetGenericArguments()[0];
       }
       for (int i = 0; i < recordCount; i++)
       {
          if(record.GetType().IsInstanceOfType(itemType))
       }
