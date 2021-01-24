    foreach(var item in SelectedItems)
    {
       Context.Pap_Pedido_ODP.Attach(item);
       Context.Entry(item).State = System.Data.Entity.EntityState.Unchanged;
    }
