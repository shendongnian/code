    using System;
    using System.Runtime.InteropServices;
    
    namespace PolygonSl
    {
        [Guid("6DC1808F-81BA-4DE0-9F7C-42EA11621B7E")]
        [System.Runtime.InteropServices.ComVisible(true)]
        [System.Runtime.InteropServices.InterfaceType(ComInterfaceType.InterfaceIsDual)]
        public interface IConfig
        {
            string GetCompany();
        }
    
        [Guid("434C844C-9FA2-4EC6-AB75-45D3013D75BE")]
        [System.Runtime.InteropServices.ComVisible(true)]
        [System.Runtime.InteropServices.ClassInterface(ClassInterfaceType.None)]
        public class Config : IConfig
        {
            public string GetCompany()
            {
                return "POL";
            }
        }
    }
