    public Task<MemberVm> GetMember(Guid id)
    {
        Member output = await Context.Members
            .SingleOrDefaultAsync(e => e.Id == id);
        return output != null
            ? new MemberVm(output)
            : null;
    }
