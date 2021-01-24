    using namespace System;
    using namespace DotNetLogger;
    namespace CliLogger { /* ... */ }
    __declspec(dllexport) void AreYouThere()
    {
        CliLogger::LoggerBridge obj;
        return obj.Result();
    }
    __declspec(dllimport) void AreYouThere();
    class UnmanagedLogger { /* ... */ }
