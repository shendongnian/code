    namespace Sppd.TeamTuner.Controllers
    {
       [Authorize]
       [ApiController]
       [Route("[controller]/[Action]")]
     public class UsersController : ControllerBase
     {
         private readonly ITeamTunerUserService _userService;
         private readonly ITokenProvider _tokenProvider;
         private readonly IAuthorizationService _authorizationService;
         private readonly IMapper _mapper;
         public UsersController(ITeamTunerUserService userService, ITokenProvider tokenProvider, IAuthorizationService authorizationService, IMapper mapper)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _authorizationService = authorizationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetByUserId(Guid userId)
        {
            // TODO: secure this call
            var user = _userService.GetByIdAsync(userId);
            return Ok(_mapper.Map<UserDto>(await user));
        }
      }
    } 
