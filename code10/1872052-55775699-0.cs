        public void addbook(string t, string a, string p, string r, string i)
        {
             
            b = new List<book>()
            {
                new book{title=t,author=a,publisher=p,releasedate=r,ISBN=i}
            };
        }
 ->
        public void addbook(string t, string a, string p, string r, string i)
        {  
            b.Add(new book { title = t, author = a, publisher = p, releasedate = r, ISBN = i });
        }
