    [assembly: InternalsVisibleTo("ProjectA")]
    ------------------------------------------
    public class ConditionVariables
    {
        public static bool IsABC { get; internal set; } = false;
    }
