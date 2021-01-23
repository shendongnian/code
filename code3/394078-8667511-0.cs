    var data = (from m in DB.MyTable
                join i in DB.UserAccess.Where(x => x.ProviderID == 42) on SqlFunctions.StringConvert((double)m.ID).Trim() equals i.ProviderUserID into useraccess
                from ua in useraccess.DefaultIfEmpty()
                select new DomainModel()
                {
                   ID = m.ID
                   Email = m.Email,
                   IsDeleted = m.IsDeleted,
                   UserID = ua.UserID,
                });
