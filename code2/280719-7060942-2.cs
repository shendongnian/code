    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace VSDesignHost
    {
        interface IStringManagerEnabled
        {
            StringManager StringManager
            {
                get;
                set;
            }
        }
    }
