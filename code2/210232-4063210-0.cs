    public static class RepositoryExtensions
    {
        public static TeamEmployee GetById(
            this IRepository<TeamEmployee> repository, int id)
        {
            return repository.Single(e => e.TeamEmployeeId == id);
        }
        public static IQueryable<Salesman> GetActiveSalesmen(
            this IRepository<ISalesmanRepository> repository)
        {
            return repository.Where(salesman => salesman.Active);
        }
        // etc
    }
