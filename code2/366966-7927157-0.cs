     Dictionary<string, string> info = new Dictionary<string, string>();
     info.Add("General information", "*");
     info.Add("Exception", m_ExceptionInfo.Exception.GetType().ToString());
     info.Add("Message",   m_ExceptionInfo.Exception.Message);
     //etc
     StringBuilder body = new StringBuilder();  
     foreach(KeyValuePair<string, string> stringPair in info)
         body.AppendFormat("{0}:{1, 20}", stringPair.Key, stringPair.Value);
