    using System;
    using System.Web.Profile;
    using System.Collections.Generic;
    
    namespace FTS.Membership.Profile
    {
        public class MyProfileProvider : ProfileBase
        {
            public bool? sex
            {
                get {
                    if (base["sex"] == null)
                    {
                        return null;
                    }
                    return (bool)base["sex"];
                }
                set { base["sex"] = value; }
            }
        }
    }
