    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace UnityConfiguration_Testing
    {
        class Program
        {
            static void Main(string[] args)
            {
                IUnityContainer container = new UnityContainer();
                container.LoadConfiguration("TestContainer");
                var _userAuthentication = container.Resolve<IUserAuthentication>();
                string validatedUser = _userAuthentication.Authenticate("testuser@user.com", "testpassword");
                string validatedUserRole = _userAuthentication.GetUserRole("testuser@user.com");
            }
        }
    }
