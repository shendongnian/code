    public void Delete(Drc.Domain.Entities.Staff.User member)
    {
        using (var ctx = new DrcDataContext())
        {
            var efUser = MapFromDomainObject(member);
            ctx.Users.Attach(efUser);
            ctx.Users.DeleteObject(efUser);
            ctx.SaveChanges();
        }
    }
