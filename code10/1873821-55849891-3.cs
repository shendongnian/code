        public async Task<ParentViewModel> GetParentViewModel(Parent parentModel)
        {
            var childrens = new List<ChildViewModel>();
            foreach (var item in parentModel.children)
            {
                var hobbies = await GetHobbies(item.ChildId);
                var friends = await GetFriends(item.ChildId);
                var child = new ChildViewModel
                {
                    ChildId = item.ChildId,
                    ChildName = item.ChildName,
                    hobbies = hobbies,
                    friends = friends
                };
                childrens.Add(child);
            }
            return new ParentViewModel
            {
                ParentId = parentModel.ParentId,
                ParentName = parentModel.ParentName,
                children = childrens
            };
        }
