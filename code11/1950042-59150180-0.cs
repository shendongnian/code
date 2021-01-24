csharp
using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Core;
using Serilog.Events;
// dotnet add package Serilog.Sinks.Console
class LogEventCollection : ILogEventEnricher
{
    // Note, this is not threadsafe
    public List<LogEvent> Events { get; } = new List<LogEvent>();
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory _)
    {
        Events.Add(logEvent);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        var collection = new LogEventCollection();
        // Create an `ILogger` with the collector wired in. This
        // also works with `LogContext.Push()`.
        var collected = Log.ForContext(collection);
        collected.Information("Hello");
        collected.Information("World");
        // One entry for each call above
        foreach (var evt in collection.Events)
        {
            Console.WriteLine(evt.RenderMessage(null));
        }
    }
}
Output:
[14:23:34 INF] Hello
[14:23:34 INF] World
Hello
World
