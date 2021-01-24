       public async Task<ParentViewModel> GetParentViewModel(Parent parentModel)
       {
          return new ParentViewModel() 
          {
             ParentId = parentModel.ParentId,
             ParentName = parentModel.ParentName,
             children = parentModel.children.Select(async item => new ChildViewModel()
             {
                 ChildId = item.ChildId,
                 ChildName = item.ChildName,
                 hobbies = await GetHobbies(item.ChildId),
                friends = await GetFriends(item.ChildId)
              }); 
           };
       }
