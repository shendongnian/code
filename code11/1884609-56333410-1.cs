    public class TeacherSubjectHandler : AuthorizationHandler<TeacherSubjectRequirement>
    {
    	readonly IHttpContextAccessor _contextAccessor;
    	readonly UserManager<AppUser> _usermanager;
    	readonly UserToTeacherService _userToTeacherService;
    
    	public ThePolicyAuthorizationHandler(IHttpContextAccessor c, UserManager<AppUser> u, _userToTeacherService s)
    	{
    		_contextAccessor = c;
    		_userManager = u;
    		_userToTeacherService = s;
    	}
    
    	protected override async Task HandleRequirementAsync(AuthorizationHandlerContext authHandlerContext, TeacherSubjectRequirement requirement)
    	{
    		var user = _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
    		var teacher = _userToTeacherService(user); //I assume this service will also retrieve teacher's subjects
    		var subjectIds = teacher.Subjects.Select(s => s.SubjectId).ToList();
    		
    		if (context.Resource is AuthorizationFilterContext filterContext)
    		{
    			var subjectIdStr = filterContext.RouteData.Values["id"].ToString();
    			if ( int.TryParse(subjectIdStr, out var subjectId) && subjectIds.Contains(subjectId) )
    			{
    				context.Succeed(requirement);
    			}
    			else
    			{
    				context.Fail();
    			}    			
    		} 
    		else
    		{
    			context.Fail();
    		}		
    	}
    }
