            RegularExpressions.Regex p 
                 = new RegularExpressions.Regex("rodrigo%otavio%diniz%waltenberg");
            using (DataContext.MyDataContext context = new MyDataContext())
            {
                var result = from u in context.users
                          where p.IsMatch(u.name)
                          select u;
            }
