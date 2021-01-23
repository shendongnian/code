    List<Book> listToSearch = new List<Book>()
       {
            new Book(){
                BookId = 1,
                CreatedDate = new DateTime(2014, 5, 27),
                Text = " test voprivreda...",
                Autor = "abc",
                Source = "SSSS"
            },
            new Book(){
                BookId = 2,
                CreatedDate = new DateTime(2014, 5, 27),
                Text = "here you go...",
                Autor = "bcd",
                Source = "SSSS"
           
            }
        };
    var blackList = new List<string>()
                {
                    "test", "b"
                }; 
    foreach (var itemtoremove in blackList)
        {
            listToSearch.RemoveAll(p => p.Source.ToLower().Contains(itemtoremove.ToLower()) || p.Source.ToLower().Contains(itemtoremove.ToLower()));
        }
    return listToSearch.ToList();
   
