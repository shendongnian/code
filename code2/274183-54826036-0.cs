        var query = context.InvoiceHeader.Where( i =>  i.DateInvoice >= model.datedu && i.DateInvoice <= model.dateau).AsQueryable();
            if(model.name != null)
            {
                query = query.Where(i =>  i.InvoiceNum.Equals(model.name));
            }
            if (model.status != 0 )
            {
                query = query.Where(i => i.REF_InvoiceStatusRecId == model.status);
            }
            if (model.paiements != 0)
            {
                query = query.Where(i => i.REF_PaymentTermRecId  == model.paiements);
            }
            query = query.AsQueryable().OrderByDescending(x => x.RecId);
