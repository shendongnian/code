    public void Iterate(IEnumerable<(string,object)>images)
    {
         HashSet<string>set=new HashSet<string>();
         foreach(var item in images)
         {
             if(!set.TryGetValue(item.item1,out object obj))
             {
                 set.Add(item.item1);
                 //React(item.item2) ---do something the first time you encounter the image 
             }
         }
     
    }
