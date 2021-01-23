    public class ErrorManager : IRequiresSessionState, IHttpModule
    {
        private const string SessionKey = "ERROR_MANAGER_SESSION_KEY";
    
        public enum Type 
        {
            None,
            Warning,
            Success,
            Error
        }
    
        /*
         * 
         * Public methods
         * 
         */
    
        public void Dispose() 
        {
        }
    
        public void Init(HttpApplication context) 
        {
            context.AcquireRequestState += new EventHandler(Initiliaze);
        }
    
        public static IList<ErrorModel> GetErrors(ErrorManager.Type type = Type.None) 
        {
            // Get all errors from session
            var errors = GetErrorData();
                
            // Destroy Keep alive
            // Decrease all errors request count
            foreach (var error in errors.Where(o => type == ErrorManager.Type.None || o.ErrorType == type).ToList())
            {
                error.KeepAlive = false;
                error.IsRead = true;
            }
    
            // Save errors to session
            SaveErrorData(errors);
    
            //return errors;
            return errors.Where(o => type == ErrorManager.Type.None || o.ErrorType == type).ToList();
        }
    
        public static void Add(ErrorModel error) 
        {
            // Get all errors from session
            var errors = GetErrorData();
            var result = errors.Where(o => o.Key.Equals(error.Key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    
            // Add error to collection
            error.IsRead = false;
    
            // Error with key is already associated
            // Remove old error from collection
            if (result != null)
                errors.Remove(result);
    
            // Add new to collection
            // Save errors to session
            errors.Add(error);
            SaveErrorData(errors);
        }
    
        public static void Add(string key, object value, ErrorManager.Type type = Type.None, bool keepAlive = false) 
        {
            // Create new error
            Add(new ErrorModel()
            {
                IsRead = false,
                Key = key,
                Value = value,
                KeepAlive = keepAlive,
                ErrorType = type
            });
        }
    
        public static void Remove(string key) 
        {
            // Get all errors from session
            var errors = GetErrorData();
            var result = errors.Where(o => o.Key.Equals(key, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
    
            // Error with key is in collection
            // Remove old error
            if (result != null)
                errors.Remove(result);
    
            // Save errors to session
            SaveErrorData(errors);
        }
    
        public static void Clear() 
        {
            // Clear all errors
            HttpContext.Current.Session.Remove(SessionKey);
        }
    
        /*
         * 
         * Private methods
         * 
         */
    
        private void Initiliaze(object o, EventArgs e) 
        {
            // Get context
            var context = ((HttpApplication)o).Context;
    
            // If session is ready
            if (context.Handler is IRequiresSessionState || 
                context.Handler is IReadOnlySessionState)
            {
                // Load all errors from session
                LoadErrorData();
            }
        }
    
        private static void LoadErrorData() 
        {
            // Get all errors from session
            var errors = GetErrorData().Where(o => !o.IsRead).ToList();
                    
            // If KeepAlive is set to false
            // Mark error as read
            foreach (var error in errors)
            {
                if (error.KeepAlive == false)
                    error.IsRead = true;
            }
    
            // Save errors to session
            SaveErrorData(errors);
        }
    
        private static void SaveErrorData(IList<ErrorModel> errors) 
        {
            // Make sure to remove any old errors
            HttpContext.Current.Session.Remove(SessionKey);
            HttpContext.Current.Session.Add(SessionKey, errors);
        }
    
        private static IList<ErrorModel> GetErrorData() 
        {
            // Get all errors from session
            return HttpContext.Current.Session[SessionKey]
                as IList<ErrorModel> ??
                new List<ErrorModel>();
        }
    
        /*
         * 
         * Model
         * 
         */
    
        public class ErrorModel 
        {
            public string Key { get; set; }
            public object Value { get; set; }
            public bool KeepAlive { get; set; }
            internal bool IsRead { get; set; }
            public Type ErrorType { get; set; }
        }
