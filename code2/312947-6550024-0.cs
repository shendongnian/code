    System.Collections.IEnumerable i = from cr in db.ComprobanteRecepcions  join c in  db.Comprobantes
    on new { cr.RFC, cr.RFCProveedor, cr.Folio, cr.Serie }  equals new { c.RFC,  c.RFCProveedor, c.Folio, c.Serie }
    where
    Convert.ToString(cr.IDSucursal) == "4" &&
    cr.RFC == "FIN020938SVR "
    select new { cr.Serie, cr.Folio, cr.IDStatusComp, c.FechaEmision, c.Comentarios, c.Total  };
    return i;
