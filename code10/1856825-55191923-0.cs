    public class RequirementHeaderListener : IPostInsertEventListener
    {
        public void OnPostInsert(PostInsertEvent e)
        {
            if (e.Entity is RequirementHeader header)
            {
                var number = e.Session.CreateSQLQuery("SELECT NEXT VALUE FOR Seq_Sequence").UniqueResult().ToString();
                header.SequenceNumber = int.Parse(number);
            }
        }
        public Task OnPostInsertAsync(PostInsertEvent e, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
