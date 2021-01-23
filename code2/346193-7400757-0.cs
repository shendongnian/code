    public class Service
    {
        private readonly DinnerRepository repo;
        private readonly Dinner dinner;
        public Service()
        {
            repo = new DinnerRepository();
            dinner = repo.GetDinner(5);
        }
    }
