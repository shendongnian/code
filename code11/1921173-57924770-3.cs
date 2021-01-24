    foreach(var item in SelectedItems)
    {
       if(Context.Pap_Pedido_ODP.Local.Contains(item))
       { // This exact instance is already associated to the Context.
         // We shouldn't need to copy anything across or do anything...
       }
       else
       {
          var existingItem = Context.Pap_Pedido_ODP.Local.SingleOrDefault(x => x.Id == item.Id);
          if(existingItem != null)
          { // A different instance matching this one already exists in the context, 
            // Here if item represents changes we would need to copy changes across to existingItem...
          }
          else
          { // Item is not associated, safe to attach.
              Context.Pap_Pedido_ODP.Attach(item);
              // ...
          }
       }
    }
