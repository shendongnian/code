    log4net:ERROR Could not create Appender [RollingLogFileAppender] of type [log4net.Appender.RollingFileAppender]. Reported error follows.
    System.UnauthorizedAccessException: Access to path 'D__Logs_' denied. (Translated from french)
       à System.IO.__Error.WinIOError(Int32 errorCode, String maybeFullPath)
       à System.Threading.Mutex.MutexTryCodeHelper.MutexTryCode(Object userData)
       à System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(TryCode code, CleanupCode backoutCode, Object userData)
       à  System.Threading.Mutex.CreateMutexWithGuaranteedCleanup(Boolean initiallyOwned, String name, Boolean& createdNew, SECURITY_ATTRIBUTES secAttrs)
       à  System.Threading.Mutex..ctor(Boolean initiallyOwned, String name, Boolean& createdNew, MutexSecurity mutexSecurity)
       à  System.Threading.Mutex..ctor(Boolean initiallyOwned, String name, Boolean& createdNew)
       à  log4net.Appender.RollingFileAppender.ActivateOptions()
       à  log4net.Repository.Hierarchy.XmlHierarchyConfigurator.ParseAppender(XmlElement appenderElement)
    log4net:ERROR Appender named [RollingLogFileAppender] not found.
