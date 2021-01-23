    StringBuilder body = new StringBuilder();    
    body.AppendFormat("Exception: {0}, Message: {1}{2}", 
                                m_ExceptionInfo.Exception.GetType(),
                                m_ExceptionInfo.Exception.Message,
                                Environment.NewLine);
    body.AppendFormat("Class: {0}, Assembly: {1}{2}", 
                                m_ExceptionInfo.GetClassName(...),
                                m_ExceptionInfo.AssemblyName,
                                Environment.NewLine);
