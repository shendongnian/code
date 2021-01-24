    public class Item
    {
       public string Id { get; set; }
       public string Cislo { get; set; }
       public string Zprava { get; set; }
       public string RecDate { get; set; }
    }
    
    var items = id.Select((id, index) => new Item() 
                                           {
                                              Id = id,
                                              Cislo = cislo[index],
                                              Zprava = zprava[index],
                                              RecDate = recDate[index]                                             
                                            }).ToList();
    
    foreach (var item in items)
    {
       string sql = " insert into contacts(id, zprava, cislo) values (@id, @zprava, @cislo)";
    
       var command = new SqlCommand(sql, connection);
       
       // bind the parameters in the sql based on the `item` object.
       // execute the command, etc..
    }
