 c#
[Route("[area]/Employee/{id:guid}/Notify/[action]")]
public class EmployeeNotificationController : BaseController
{
    // some code...
    public async Task<bool> RegistrationPending(string id)
    {
        return await _employeeRegistrationService
            .NotifyRegistrationPendingAsync(User.UserId(), id);
    }
    // some more code...
}
