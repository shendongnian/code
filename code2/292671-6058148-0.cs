    using (var Db = new L2S.DataClasses1DataContext())
    {    
     ...
     // leave out customer.city_Id = 57834;  but replace with
     customer.City = Db.Cities.Single (i=> i.id =   57834 ); 
     Db.SubmitChanges();
     }
