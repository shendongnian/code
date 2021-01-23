    return (from c in _Entities.Company
                   where c.Deleted == false
                    select new
                    {
                        c.Name,
                        ParentMember = new
                        {
                            c.ParentMember.Name
                        }
                    })
    .AsEnumerable()
    .Select(c=> new Member
                    {
                        Name = c.Name,
                        ParentMember = new Member
                        {
                            Name = c.ParentMember.Name
                        }
                    }); 
