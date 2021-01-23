    public TRet InDb<TRet>(Func<BodModelContainer, TRet> workingWithDb) {
      TRet ret = default(TRet);
      using (var dbContext = new BodModelContainer()) {
        ret = workingWithDb(dbContext);
      }
      return ret;
    }
    public Member GetMemberById(int memberId) {
      return InDb(dbContext => { return dbContext.Members.Find(new[] { memberId }); });
    }
