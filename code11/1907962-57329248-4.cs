    public async Task<MemberVm> GetMember(Guid id)
    {
      Member member = await Context.Members
        .SingleOrDefaultAsync(e => e.Id == id);
    
      return member != null
        ? new MemberVm(member)
        : null;
    }
