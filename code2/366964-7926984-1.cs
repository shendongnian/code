    StringBuilder body = new StringBuilder();    
    body.AppendFormat("Exception: {0}, Message: {1}{2}Class: {3}, Assembly: {4}{5}", 
                                m_ExceptionInfo.Exception.GetType(),
                                m_ExceptionInfo.Exception.Message,
                                Environment.NewLine,                              
                                m_ExceptionInfo.GetClassName(...),
                                m_ExceptionInfo.AssemblyName,
                                Environment.NewLine);
    body.AppendFormat("App-Domain: {0}, Source-File: {1}{2}",
                                m_ExceptionInfo.AppDomainName,
                                m_ExceptionInfo.GetFileName(...),
                                Environment.NewLine);
