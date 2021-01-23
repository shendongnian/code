    public static void InsertAgent(int authorityID, int agentID)
    {
        using (var unitOfWork = new UnitOfWork())
        {
            var daoAuthority = new ConcreteDAO<Authority>(unitOfWork);
            var daoAgent = new ConcreteDAO<Agent>(unitOfWork);
      
            var authority = new Authority { ID = authorityID,
                Agents = new List<Agent>() };
            daoAuthority.Attach(authority);
            var agent = new Agent { ID = agentID };
            daoAgent.Attach(agent);
            authority.Agents.Add(agent);
            unitOfWork.SaveChanges();
        }
    }
