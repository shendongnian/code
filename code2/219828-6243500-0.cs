    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using ActiveDs;
     
    namespace Foo.Repository.AdUserProfile
    {
        public class ADUserProfileValueTranslate
        {
            public static string ConvertUserPrincipalNameToNetBiosName(string userPrincipleName)
            {
                NameTranslate nameTranslate = new NameTranslate();
                nameTranslate.Set((int)ADS_NAME_TYPE_ENUM.ADS_NAME_TYPE_USER_PRINCIPAL_NAME, userPrincipleName);
                return nameTranslate.Get((int) ADS_NAME_TYPE_ENUM.ADS_NAME_TYPE_NT4);
            }
        }
    }
