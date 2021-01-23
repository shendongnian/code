    public void InDb(Action<BodModelContainer> workingWithDb) {
      using (var dbContext = new BodModelContainer()) {
        workingWithDb(dbContext);
      }
    }
    public Member GetMemberById(int memberId) {
      Member member;
      InDb(dbContext => { member = dbContext.Members.Find(new[] { memberId }); });
      return member;
    }
