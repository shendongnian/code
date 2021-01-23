		//Here is a LinqToSql example but it should work with EF too.Taking into consideration your mappings I would have the following approach in handling a many to many relationship:
		
		//1. First You need to save you records into the tables as many to many relationship
		[Test]
        public void CanSaveGroupUsers()
        {
            var group = Group { CreatedDate = DateTime.UtcNow, Name = "The Rookies" };
            var groupId = _groupRepository.SaveGroup(group);
            var user = new User { CreatedDate = DateTime.Now, Name = "Justin Bieber" };
            var userId = _userRepository.SaveUser(user);
            var userGroup = new UserGroup { GroupId = groupId, UserId = userId };
            _group.SaveUserGroup(userGroup);
        }
		
		//2. Then you can retrive them this way:
		[Test]
        public void CanGetGroupUsers()
        {
			var groupIds = new List<int>{1,2,3,4};
			var users = _usersRepository.GetAllUsers();
			var specificUsersList = (users.AsQueryable().Where(user => groupIds.Contains(user.UserGroups.FirstOrDefault().GroupId)));
		}
		
		//3. I attached my repository code just in case
		public IQueryable<User> GetAllUsers()
        {
            _db.ObjectTrackingEnabled = false;
            return _db.Users;
        }
		public int SaveGroup(Group Group)
        {
            var dbGroup = new Group
            {
                Name = Group.Name,
                CreatedDate = Group.CreatedDate
            };
            _db.Groups.InsertOnSubmit(dbGroup);
            _db.SubmitChanges();
            return dbGroup.Id;
        }
		
		public int SavUser(User user)
        {
            var dbUser = new User
            {
                CreatedDate = user.CreatedDate,
                Name = user.Name
            };
            _db.Users.InsertOnSubmit(dbUser);
            _db.SubmitChanges();
            return dbUser.UserId;
        }
		
		 public void SaveUserGroup(UserGroup userGroup)
        {
            var dbUserGroup = new UserGroup
            {
                GroupId = userGroup.GroupId,
                UserId = userGroup.UserId
      
            };
            _db.UserGroups.InsertOnSubmit(dbUserGroup);
            _db.SubmitChanges();
        }
		
		//Hope this helps:)
