    Dim bar As WebProxy = WebProxy.GetDefaultProxy
    Dim scriptEngineProperty = bar.GetType().GetProperty("ScriptEngine", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
    Dim scriptEngineObject as Object = scriptEngineProperty.GetValue(bar, Nothing)
    Dim acsProperty As PropertyInfo = scriptEngineObject.GetType().GetProperty("AutomaticConfigurationScript", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
    Dim acsObject as Object = acsProperty.GetValue(scriptEngineObject, Nothing)
    Dim localPathProperty As PropertyInfo = acsObject.GetType().GetProperty("LocalPath", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance)
    Dim value As String = localPath.GetValue(acsObject, Nothing).ToString
