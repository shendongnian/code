    CardTypes = new List<SelectListItem>();
    var ctypes = db.ExecuteReaderDynamic( "CardType_GetAll", null, System.Data.CommandType.StoredProcedure )
          .Select( d =>
            new SelectListItem
        {
            Text = d.Name,
            Value = d.ID.ToString()
                        Selected = false
        } );
    CardTypes.AddRange( ctypes );
    
    SelectList oCards = new SelectList(oCardTypes, (int)CardType.Mastercard);
