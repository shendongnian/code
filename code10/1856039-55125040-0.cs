c#
[AbpAuthorize(PermissionNames.Pages_Users)]
public class UserAppService : AsyncCrudAppService<...>, IUserAppService
These are your options:
1. Remove the injection of `IUserAppService` from `BacklogController`, since you are not using it.
        // private readonly IUserAppService _userAppService;
        private readonly BacklogAppService _backlogAppService;
        // public BacklogController(IUserAppService userAppService, BacklogAppService backlogAppService)
        public BacklogController(BacklogAppService backlogAppService)
        {
            // _userAppService = userAppService;
            _backlogAppService = backlogAppService;
        }
2. Log in as tenant admin, which has `PermissionNames.Pages_Users` granted by default.
3. Grant `PermissionNames.Pages_Users` to the user that you have logged in to.
