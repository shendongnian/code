private static string logFilePath;
private static readonly object _lock = new object();
public static void log(string serviceId, string className, string error, Exception exception) {
    string toLog = $"{className}: {error}";
    lock (_lock) {
        if (string.IsNullOrEmpty(logFilePath)) {
            string fileName = $"log-{DateTime.Now.Month}-{DateTime.Now.Day}-{serviceId}.log"; // you can also date if you want
            logFilePath = Path.Combine(<path to save>, fileName);
            if (!File.Exists(logFilePath)) {
                // create the file
            }
        }
        if (exception != null) { // you can log exceptions and debug messages too
            toLog += Environment.NewLine + exception.ToString();
        }
        toLog = $"{<you can add here date if you want>} - {toLog}";
        using (StreamWriter writer = File.AppendText(logFilePath)) {
            writer.WriteLine(toLog);
        }
    }
}
And of course, you can improve how you want, add log levels, etc.
