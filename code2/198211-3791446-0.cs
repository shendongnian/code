    public enum LoggerTypes
    {
        Normal,
        Super
    }
    public class LoggerAttribute : ActionFilterAttribute
    {
        public LoggerAttribute() : base()
        {
            LoggerType = LoggerTypes.Normal;
        }
        public LoggerAttribute(LoggerTypes loggerType) : base()
        {
            LoggerType = loggerType;
        }
        public LoggerTypes LoggerType
        {
            get; 
            set;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (LoggerType == LoggerTypes.Super)
            {
                //
            }
            else
            {
                //
            }
        }
