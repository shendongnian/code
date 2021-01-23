    private void addData(Header header)
     {
        if(null == header)
        {
           // if header null what you can do... e.g log header is null 
           return; 
        }
        if(null == header.headerItems)
        {
            header.headerItems = ....; // create new header item collection 
        }
        Data d2 = new Data("pol");
        header.headerItems.Add(d2);
     }
