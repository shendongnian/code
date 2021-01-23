    //  ProxyUser.cs. It should be in the same assembly as ActiveDirectoryUserRepository 
    internal class ProxyUser : User
    {
       private ActiveDirectoryUserRepository _repository ;
       internal ProxyUser(ActiveDirectoryUserRepository repository)
       {
           _repository = repository;
       }
       internal string IList<string> GroupNames { get; set; }
       
       private IList<Group> _groups;
       public override IList<Group> Groups 
       { 
          get
          {
             if (_groups == null)
             {
                if (GroupNames != null && GroupNames.Count > 0)
                {
                    _groups = new List<Group>();
                    foreach(string groupName in GroupNames)
                       _groups.Add(_repository.FindGroupByName(groupName);
                }
             }
             return _groups;
           }
           
           set
           {
               _groups = value;
           }
        }
    }
------------------------------------------------------------
    
    // ProxyGroup.cs
    internal class ProxyGroup : Group
    {
        // This class should be similar to ProxyUser
    }
