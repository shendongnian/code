        public UserRepository GetUserRepositoryMock(bool mockSelect=true, bool mockSelectOne=true, bool mockSave=true ... etc etc)
        {
            // mock all UserRepository instances.
            var userRepositoryMock = Isolate.Fake.Instance<UserRepository>();
            Isolate.Swap.AllInstances<UserRepository>().With(userRepositoryMock);
            // make all public UserRepository members throw a NotSupportedException.
            if(mockSelect) 
                Isolate.WhenCalled(() => userRepositoryMock.Select(null)).WillThrow(new NotSupportedException());
            if (mockSelectOne)
                Isolate.WhenCalled(() => userRepositoryMock.SelectOne(null)).WillThrow(new NotSupportedException());
            if(mockSave)
                Isolate.WhenCalled(() => userRepositoryMock.Save(null)).WillThrow(new NotSupportedException());
            
            // ... et cetera until all public members of UserRepository will throw NotSupportedException where the corresponding flag is true.
        }
