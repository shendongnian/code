    public List<bksb_Users> SearchStudents(string reference, string firstname, string lastname) 
        { 
            var anon = (from u in context.bksb_Users 
                    where u.userName.Contains(reference) 
                    && u.FirstName.Contains(firstname) 
                    && u.LastName.Contains(lastname) 
                    orderby u.FirstName, u.LastName 
                    select new 
                     { 
                         user_id = u.user_id, 
                         userName = u.userName, 
                         FirstName = u.FirstName, 
                         LastName = u.LastName, 
                         DOB = u.DOB 
                     }).Take(100).ToList(); 
            return anon.Select(z => new bksb_Users()
            {
                user_id = z.user_id, userName = z.userName, FirstName = z.FirstName, DOB = z.DOB
            }).ToList();
        } 
