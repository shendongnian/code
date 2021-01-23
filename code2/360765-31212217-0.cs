    Mapper.CreateMap<ExpandoObject, UserModel>()
        .ForAllMembers((options) => options.ResolveUsing((resolution) =>
            {
                var dictionary =  (IDictionary<string, object>) resolution.Context.SourceValue;
                return dictionary[resolution.Context.MemberName];
            }));
    ...
    dynamic CurUser = _users.GetSingleUser(UserID);   
    var retUser = Mapper.Map<UserModel>(CurUser);
