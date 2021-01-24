    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using Soft_Arch_WebAPI.Models;
    
    namespace Soft_Arch_WebAPI.Controllers
    {
        [ApiController]
        [Route("[controller]")]
        public class UserController : ControllerBase
        {
            [HttpPost("Register")]
            public String Register()
            {
                return "Hier werden User registriert";
                //Get Values from Form and Send to Service
            }
    
            [HttpPost("login")]
            public String Login()
            {
                return "Hier werden User eingeloggt";
                //Get Values from Form and Send to Service
            }
    
            [HttpPut]
            public String ResetPWD(int ID, String Password)
            {
                return "Hier können User Ihr Passwort ändern";
                //Get Values from Form and Send to Service
            }
        }
    }
