    public class CustomUserAuth : AuthUserSession
    {
        public override void OnRegistered(IRequest req, IAuthSession session, 
            IServiceBase authService)
        {
            var authRepo = HostContext.AppHost.GetAuthRepository(req);
            using (authRepo as IDisposable)
            {
                var userAuth = (AppUser)authRepo.GetUserAuth(session.UserAuthId);
                userAuth.BirthDateRaw = request.FormData["BirthDateRaw"];
                authRepo.SaveUserAuth(userAuth);
            }
        }
    }
 
