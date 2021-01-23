    public MemberViewModel GetSingle( Expression<Func<Member,bool>> whereCondition )
    {
        var member = this.MemberRepository.GetSingle( whereCondition );
        if (member != null)
        {
            return new MemberViewModel( member );
           // or however you map from member to its view model
        }
        return null;
    }
