    public static void InsertAgent(int authorityID, int agentID)
    {
        using (var unitOfWork = new UnitOfWork()) // unit of work = context
        {
            var daoAuthority = new ConcreteDAO<Authority>(unitOfWork);
            var daoAgent = new ConcreteDAO<Agent>(unitOfWork);
      
            var authority = daoAuthority.Single(p => p.ID.Equals(authorityID));
            var agent = daoAgent.Single(p => p.ID == agentID);
            authority.Agents.Add(agent);
            unitOfWork.SaveChanges();
        }
    }
