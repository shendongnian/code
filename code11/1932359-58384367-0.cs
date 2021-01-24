    using System;
    using Microsoft.AspNetCore.Identity;
    namespace MyProject.Identity
    {
        public class MyProjectIdentity : IdentityUser<string>
        {
    		//other properties...
    		
            public int ProfilePicId { get; set; }
    		
    		//more other properties...
        }
    }
