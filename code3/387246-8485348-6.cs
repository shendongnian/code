          if(IsActive==true)
           {
     var ien_content = from c in this.DataContext.tbl_Contents
                      where c.ContentTypeID == id
                      && c.Active == null
                      orderby c.RegisterDate descending 
                      select c;
                      
                      if(ien_content.Count() > 0 )
                      {
                         return ien_content.ToList();
                       } 
                      else {//no records}
           }
           else
           {
                 var ien_content = from c in this.DataContext.tbl_Contents
                  where c.ContentTypeID == id
                  && Convert.ToInt32(c.Active) > 0
                  orderby c.RegisterDate descending 
                  select c;
                  
                  if(ien_content.Count() > 0 )
                  {
                    return ien_content.ToList();
                   } 
                  else {//no records}
            }
