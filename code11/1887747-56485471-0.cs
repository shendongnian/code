    public sealed class LogLevel : IComparable, IEquatable<LogLevel>, IConvertible
    {
        /// <summary>
        /// Gets all the available log levels (Trace, Debug, Info, Warn, Error, Fatal, Off).
        /// </summary>
        public static IEnumerable<LogLevel> AllLevels => allLevels;
