    public IEnumerable<ProductViewModel> GetProducts(int categoryID)
    {
       List<ProductViewModel> lstPVM = new List<ProductViewModel>();
            
       var anonymousObjResult = from p in db.Products
                                where p.CategoryID == categoryID 
                                select new
                                {
                                    CatID = p.CategoryID,
                                    Name = p.Name
                                };
            // NOTE: If you have any dates that are nullable and null, you'll need to
            // take care of that:  ClosedDate = (DateTime?)p.ClosedDate ?? DateTime.Now
            // If you want a particular date, you have to define a DateTime variable,
            // assign your value to it, then replace DateTime.Now with that variable. You
            // cannot call a DateTime.Parse there, unfortunately. 
            // Using 
            //    new Date("1","1","1800"); 
            // works, though. (I add a particular date so I can edit it out later.)
            // I do this foreach below so I can return a List<ProductViewModel>. 
            // You could do: return anonymousObjResult.ToList(); here
            // but it's not as clean and is an anonymous type instead of defined
            // by a ViewModel where you can control the individual field types
            foreach (var a in anonymousObjResult)
            {                
                ProductViewModel pvm = new ProductViewModel();
                pvm.ID = a.CatID;  
                pvm.Name = a.Name;
                lstPVM.Add(rvm);
            }
            // Obviously you will just have ONE item there, but I built it 
            // like this so you could bring back the whole table, if you wanted
            // to remove your Where clause, above.
            return lstPVM;
        }
