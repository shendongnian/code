    using System;  
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.Unity;
    using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using Microsoft.Practices.EnterpriseLibrary.Logging.Configuration.Unity;
    using Microsoft.Practices.Unity;
    namespace xzy
    {
        public class abc
        {
        /// <summary>
        /// Unity Container with key dependencies registered
        /// </summary>
        public static UnityContainer UC { get; private set; }
        private static IUnityContainer _IUContainer;// not sure if this is needed
        public static LogWriter LogWtr;
        public static ExceptionManager ExcMgr;
        /// <summary>
        /// Controller Bootstrap to manage as singleton via static properties and therefore ONLY 1 Unity Container
        /// </summary>
        static bootstrap()
        {
     
            UC = new UnityContainer(); // one container per work process. managing and resolving dependencies
        //  DO NO DO THIS WITH NEW VERSION OF Enterprise LIBRARY this was v5, v6 does not need this
            **// now we tell unity about the container manager inside EntLib.
            // we dont want 2 containers, so we tell UNity look after EntLib as well please
          //  UC.AddNewExtension<EnterpriseLibraryCoreExtension>();
        
            //No need to add The extensions individually.
            //no longer required and indeed Library documents this as obselete
           //    UC.AddNewExtension<LoggingBlockExtension>();** 
        //================ END OF OLD V5 approach  ========================
        
            LogWtr = UC.Resolve<LogWriter>();
            ExcMgr = UC.Resolve<ExceptionManager>();
            // other initializations here
        }
        }
    }
