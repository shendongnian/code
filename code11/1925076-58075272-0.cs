    public async Task<IEnumerable<ApplicationUser>> GetBirthdayUsersCurrentMonth()
        {
            return await ApplicationDbContext.Users
                .Where(x => x.Gender != ApplicationUser.GenderTypes.generic)
                //.Where(x => x.BirthDate.GetValueOrDefault().Month == DateTime.Now.Month)
                .Where(x => x.BirthDate.Value.Month == DateTime.Now.Month)
                .Where(x => x.RetireDate == null)
                .OrderBy(x => x.BirthDate)
                .ToListAsync();
        }
