        // I don't want people to have to add configuration information to get this logging. 
        // I know this brittle, but don't judge... please. It makes consuing the api so much
        // easier.
        private static void EnsureLog4NetListener()
        {
            try
            {
                Assembly compositionAssembly = Assembly.GetAssembly(typeof (CompositionContainer));
                Type compSource = compositionAssembly.GetType("System.ComponentModel.Composition.Diagnostics.CompositionTraceSource");
                PropertyInfo canWriteErrorProp = compSource.GetProperty("CanWriteError");
                canWriteErrorProp.GetGetMethod().Invoke(null,
                                                        BindingFlags.Public | BindingFlags.NonPublic |
                                                        BindingFlags.Static, null, null,
                                                        null);
                Type traceSourceTraceWriterType =
                    compositionAssembly.GetType(
                        "System.ComponentModel.Composition.Diagnostics.TraceSourceTraceWriter");
                TraceSource traceSource = (TraceSource)traceSourceTraceWriterType.GetField("Source",
                                                                              BindingFlags.Public |
                                                                              BindingFlags.NonPublic |
                                                                              BindingFlags.Static).GetValue(null);
                traceSource.Listeners.Add(new Log4NetTraceListener(logger));                
            }
            catch (Exception e)
            {
                logger.Value.Error("Cannot hook MEF compisition listener. Composition errors may be swallowed.", e);
            }
        }  
