     if (date1!=null)
            {
                custQuery = custQuery.Where(c => DateTime.ParseExact(c.docDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) >= date1);
            }
            if (date2 != null)
            {
                custQuery = custQuery.Where(c => DateTime.ParseExact(c.docDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) <= date2);
            }
           
            return custQuery.ToList();
