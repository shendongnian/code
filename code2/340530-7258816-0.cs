    using(DAL dal = new DAL())
    {
        DAL.DAL_OrdenDeCompra dalOrdenDeCompra = dal.OrdenDeCompra;
        DAL.DAL_ItemDeUnaOrden dalItemDeUnaOrden = dal.ItemDeUnaOrden;
        using (TransactionScope transaccion = new TransactionScope())
        {
            dal.Open();
            //Insertion of the order
            orden.Id = dalOrdenDeCompra.InsertarOrdenDeCompra(orden.NumeroOrden, orden.PuntoDeEntregaParaLaOrden.Id, (int)orden.TipoDeCompra, orden.FechaOrden, orden.Observaciones);
            foreach (ItemDeUnaOrden item in orden.Items)
            {                       
                //Insertion of each one of its items. 
                dalItemDeUnaOrden.InsertarItemDeUnaOrden(orden.Id, item.CodigoProductoAudifarma, item.CodigoProductoJanssen, item.CodigoEAN13, item.Descripcion, item.CantidadOriginal, item.ValorUnitario);
            }
            transaccion.Complete();
        }
        return true;
    }
