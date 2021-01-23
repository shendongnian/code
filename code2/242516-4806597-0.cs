    Database master = Factory.GetDatabase("master"); 
    master.SelectItems(query); 
    
    Database web = Factory.GetDatabase("web"); 
    web.SelectItems(query); 
