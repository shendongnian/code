    private Expression<Func<TDestination, TProperty>> GetMappedSelector<TSource, TDestination, TProperty>(Expression<Func<TSource, TProperty>> selector)
    {
    	var map = Mapper.FindTypeMapFor<Person, Entity.Person>();
    		
    	var mInfo = ReflectionHelper.GetMemberInfo(selector);
    
    	if (mInfo == null)
    	{
    		throw new Exception(string.Format(
    			"Can't get PropertyMap. \"{0}\" is not a member expression", selector));
    	}
    
    	PropertyMap propmap = map
    		.GetPropertyMaps()
    		.SingleOrDefault(m => 
    			m.SourceMember != null && 
    			m.SourceMember.MetadataToken == mInfo.MetadataToken);
    
    	if (propmap == null)
    	{
    		throw new Exception(
    			string.Format(
    			"Can't map selector. Could not find a PropertyMap for {0}", selector.GetPropertyName()));
    	}
    
    	var param = Expression.Parameter(typeof(TDestination));
    	var body = Expression.MakeMemberAccess(param, propmap.DestinationProperty.MemberInfo);
    	var lambda = Expression.Lambda<Func<TDestination, TProperty>>(body, param);
    
    	return lambda;
    }
