    public User(IUserRepsoitory userRepository)
    {
     this.userRepsoitory = userRepository;
    }
    
    public void IsValid()
    {
     return userRepository.IsPsswordValid(this);
    }
