     var userGroupsQueryable = _entities.UserGroupMembership.Where(ug => ug.UserID == UserID)
                                       .Select(a => a.GroupMembership);
     var  contactsGroupsQueryable = _entities.CompanyContactsSecurity;
     var listOfCompanies =
                from company in _entities.CompanyDetail
                select new
                {
                    Company = company,
                    Contacts = (from c in userGroupsQueryable
                                join p in contactsGroupsQueryable on c equals p.GroupID
                                where company.CompanyContacts.Any(cc => cc.CompanyID == p.CompanyID)
                                select p.CompanyContacts)
                };
