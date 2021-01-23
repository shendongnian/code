    public IEnumerable<Problem> Create(int quantify)
    {
        HashSet<Problem> problems = new HashSet<Problem>();
        for (int i = 0; i < quantify; i++)
        {
            var problem = Create();
            if(!problems.Contains(problem))
            {
               yield return problem;
               problems.Add(problem);
            }
        }
    }
