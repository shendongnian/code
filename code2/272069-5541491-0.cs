        public List<Contact> Get(FilterValues filter)
        {
            using (var context = new AdventureWorksEntities())
            {
                IQueryable<Contact> query = context.Contacts.Where(c => c.ModifiedDate > DateTime.Now);
                if (!string.IsNullOrEmpty(filter.FirstName))
                {
                    query = query.Where(c => c.FirstName == filter.FirstName);
                }
                if (!string.IsNullOrEmpty(filter.LastName))
                {
                    query = query.Where(c => c.LastName == filter.LastName);
                }
                return query.ToList();
            }
        }
