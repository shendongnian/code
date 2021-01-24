        //get all string dates from product list
        var GetDates = ProductList.Select(m => m.CreatedDate).ToList();
        //create DateTime list to convert the string dates to DateTime Formate
        List<DateTime> dt = new List<DateTime>();
        foreach (var item in GetDates)
        {
            dt.Add(Convert.ToDateTime(item));
        }
        //sort the DateTime "dt" list
        var SortedDatesList = dt.OrderByDescending(x => x)
            .Select(x => x.ToString("dd-MMM-yyyy"));
        //Create a list of Class Product , and add products according to sorted dates
        List<Product> _NewProducts = new List<Product>();
        foreach (var item in SortedDatesList)
        {
            _NewProducts.Add(ProductList.Where(m=>m.CreatedDate == item).FirstOrDefault());
        }
