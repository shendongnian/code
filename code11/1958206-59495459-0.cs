    switch(sOrdenar){
       case "Field1"
         clientes = nSentido == -1 ? clientes.OrderBy(entity=> entity.Field1) : clientes.OrderByDescending(entity=> entity.Field1);
         break;
       case "OtherField"
              clientes = nSentido == -1 ? clientes.OrderBy(entity=> entity.OtherField) : clientes.OrderByDescending(entity=> entity.OtherField);
         break;
    }
