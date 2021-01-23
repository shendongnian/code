    using (ISession session = MyConnection.GetCurrentSession())
        {
            var brands = from b in session.QueryOver<BrandTable>().List()
                                 orderby b.Name
                                 select new {Id = b.id, Name = b.Name};
            return brands.ToList();
        }
