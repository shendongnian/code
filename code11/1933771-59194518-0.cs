c#
  var p = await wc.Product.GetAll(new Dictionary<string, string>() {
                    {"tag", Suppliers.tagid },
                    { "per_page", "80" } }); ;
  foreach (var item in p)
            {
                foreach (var z in item.images)
                {
                    if (item.images != null)
                    {
                        var YourBinding = z.src;
                    }
                }
            }
//There is more then likely a better way to go about it but its how I ended up sorting the problem for one of the Pull Methods of mine
