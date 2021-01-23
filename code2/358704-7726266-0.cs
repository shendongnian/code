    public IEnumerable<Job> GetAllJobs() {
        try {
            using(var jobsRepository = new JobsRepository()) // !!! Use Dependency Injection, etc
            {
                  return jobsRepository .GetAll().ToList();
            }
        } catch (CentralRepositoryException ex) {
            //logging code to go here
            //throw back to caller
            throw;
        } catch (Exception ex) {
            //logging code to go here
            //throw simple exception to caller
            throw new CentralRepositoryException("A general exception has occurred", ex); // !!!!!! INCLUDE THE ORIGINAL ERROR !!!!!!!
        }
    }
