 using Microsoft.AspNetCore.Identity;
using System;
namespace WebApp1.Areas.Identity.Data
{
    public class WebApp1User : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}
Take a look here [Microsoft docs][1]
  [1]: https://docs.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-2.2&tabs=visual-studio
