        public User GetTimeSheet(int userid)
            {
                 var mydata =  _context.Users.Where(u => u.Id ==userid).Include(u => u.Projects).ThenInclude(t=> t.TimeSheetData).FirstOrDefault().Select(d=>d.TheDataYouWant);
                 return mydata.myUser;
            }
