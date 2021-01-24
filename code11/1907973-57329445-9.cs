    public Task<MemberVm> GetMember(Guid id)
    {
        Task<Member> output = Context.Members
            .SingleOrDefaultAsync(e => e.Id == id);
        return output.ContinueWith((Task<Member> awaitedOutput) => 
            awaitedOutput.Result != null ? new MemberVm(output.Result) : null);
    }
