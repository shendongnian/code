    public class Redirector : IHttpModule
        {
            #region --- Private Properties ---
            private static Logger logger = LogManager.GetCurrentClassLogger();
            private static ConcurrentDictionary<string, string> Dictionary = new ConcurrentDictionary<string, string>();
            #endregion
    
    
            #region --- LifeCycle ---
            public void Dispose()
            {
    
            }
    
            public void Init(HttpApplication context)
            {
                logger.Error("RedirectModule: I have been initialized");
                FillDictionary();
    
                context.EndRequest += EndHandler;
    
            }
    
            public bool IsReusable
            {
                get { return true; }
            }
    
            private void FillDictionary()
            {
                logger.Error("Filling dictionary");
                try
                {
                    var currentDir = Directory.GetCurrentDirectory();
    
                    ResourceManager rm = new ResourceManager("Resources.resx",
                    Assembly.GetExecutingAssembly());
    
                    var text = Resources.DICTIONARY_FILE;
                    var parsedText = text.Split('\n');
                    foreach (var row in parsedText)
                    {
                        var split = row.Split(';');
                        if (split == null || split.Length != 2)
                        {
                            continue;
                        }
    
                        if(!Dictionary.ContainsKey(split[0]))
                        {
                            logger.Trace($"Adding key {split[0]}");
                            Dictionary.TryAdd(split[0], split[1]);
                        }                    
                    }
                    
                }
                catch(Exception exception)
                {
                    logger.Error(exception, "Unable to fill dictinary");
                }
            }
    
            #endregion
    
            #region --- Handlers ---
    
            private void EndHandler(object sender, EventArgs e)
            {
                logger.Trace("RedirectModule: End of reqest catched");
                try
                {
                    
                    HttpApplication application = (HttpApplication)sender;
                    var code = application.Response.StatusCode;
                    Exception currentException = application.Server.GetLastError();
                    HttpException httpException = currentException != null ? (currentException as HttpException) : null;
                    HttpContext context = application.Context;
    
                    if (httpException != null)
                    {
                        if (httpException.GetHttpCode() == 404)
                        {
                            logger.Trace($"RedirectModule: 404 catched in ending as exception, original path: {context.Request.Url}");
                            if (Dictionary.ContainsKey(context.Request.Url.ToString()))
                            {
                                context.Response.Redirect(Dictionary[context.Request.Url.ToString()]);
                                logger.Trace($"redirecting to {Dictionary[context.Request.Url.ToString()]}");
                            }
                            else
                            {
                                logger.Trace($"Dictionary contains no record for  {Dictionary[context.Request.Url.ToString()]}");
                                logger.Trace($"Current amount of keys in dictionary is: {Dictionary.Count}");
                            }
                        }
                        else
                        {
                            logger.Error("RedirectModule: Unknown catched as ending");
                        }
                    }
                    else if (code == 404)
                    {
                        logger.Trace($"RedirectModule: 404 catched in ending with no exception, original Url: {context.Request.Url}");
                        if (Dictionary.ContainsKey(context.Request.Url.ToString()))
                        {
                            context.Response.Redirect(Dictionary[context.Request.Url.ToString()]);
                            logger.Trace($"redirecting to {Dictionary[context.Request.Url.ToString()]}");
                        }
                        else
                        {
                            logger.Trace($"Dictionary contains no record for  {Dictionary[context.Request.Url.ToString()]}");
                            logger.Trace($"Current amount of keys in dictionary is: {Dictionary.Count}");
                        }
                    }
                    else if(code != 200)
                    {
                        logger.Trace("Some other error code catched");
                    }
                }
                catch (Exception exception)
                {
                    logger.Error(exception, "RedirectModule: Encountered and exception");
                }
            }
    
            #endregion
    
    
        }
    }
