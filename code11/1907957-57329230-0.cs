    public async Task<MemberVm> GetMember(Guid id)
    {
      var output = await Context.Members
        .SingleOrDefaultAsync(e => e.Id == id);
      
      if (output == null)
         return null;
         
      return new MemberVm(output);
    }
