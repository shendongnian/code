    public SoccerController([Tag("Soccer")]ITeamRepository repository)
    {
        _repository = repository;
    }
    
    public SwimmingController([Tag("Swimming")]ITeamRepository repository)
    {
        _repository = repository;
    }
