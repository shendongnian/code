using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebAngular.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
namespace WebAngular.Controllers
{
    [ApiController]
    [Route("getUserProfileAsync")]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserProfileController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<object> Get()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var fullName = user.FirstName + ' ' + user.LastName;
            
            return Ok(new
            {
                user.Id,
                user.PhoneNumber,
                user.LastName,
                user.FirstName,
                user.MiddleName,
                user.Gender,
                user.AboutUser,
                user.BirthDate,
                fullName
            });
        }
    }
}
