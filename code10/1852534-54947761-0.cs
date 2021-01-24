cs
public class ProcessSubmission : IRequest
{
    public User User { get; set; }
    public ICollection<Submission> Submissions { get; set; }
}
public class ProcessSubmissionHandler : IRequestHandler<ProcessSubmission>
{
    public async Task<Unit> Handle(ProcessSubmission request, CancellationToken cancellationToken)
    {
        // Persist the user in the database
        var userId = PersistTheUser(request.User);
        foreach (var submission in request.Submissions)
        {
            // Persist each submission with questions and answers
        }
    }
}
