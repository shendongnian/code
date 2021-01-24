    public Task<MemberVm> GetMember(Guid id)
    {
        Task<Member> output = Context.Members
            .SingleOrDefaultAsync(e => e.Id == id);
        return output.ContinueWith((Member awaitedOutput) => 
            awaitedOutput != null ? new MemberVm(output) : null);
    }
