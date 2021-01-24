    interface IManager<TEntity> where TEntity : class
        {
            IList<TEntity> GetAll();
            TEntity GetById(int id);
            void Add(TEntity entity);
            void Update(TEntity entity);
            void Remove(int id);
            int GenerateContactId();
            IList<TEntity> Search(Func<TEntity, bool> p);
        }
    
        class BinaryContactManager : IManager<Contact>
        {
            public void Add(Contact entity)
            {
                throw new NotImplementedException();
            }
    
            public int GenerateContactId()
            {
                throw new NotImplementedException();
            }
    
            public IList<Contact> GetAll()
            {
                throw new NotImplementedException();
            }
    
            public Contact GetById(int id)
            {
                throw new NotImplementedException();
            }
    
            public void Remove(int id)
            {
                throw new NotImplementedException();
            }
    
            public IList<Contact> Search(Func<Contact, bool> p)
            {
                throw new NotImplementedException();
            }
    
            public void Update(Contact entity)
            {
                throw new NotImplementedException();
            }
        }
    
        class BinaryUserManager : IManager<User>
        {
            public void Add(User entity)
            {
                throw new NotImplementedException();
            }
    
            public int GenerateContactId()
            {
                throw new NotImplementedException();
            }
    
            public IList<User> GetAll()
            {
                throw new NotImplementedException();
            }
    
            public User GetById(int id)
            {
                throw new NotImplementedException();
            }
    
            public void Remove(int id)
            {
                throw new NotImplementedException();
            }
    
            public IList<User> Search(Func<User, bool> p)
            {
                throw new NotImplementedException();
            }
    
            public void Update(User entity)
            {
                throw new NotImplementedException();
            }
        }
