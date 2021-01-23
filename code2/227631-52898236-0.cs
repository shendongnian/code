	public class Logger {
		private static readonly System.Collections.Generic.Dictionary<string, Logger> Loggers = new System.Collections.Generic.Dictionary<string, Logger>();
		private readonly string _name;
		private LoggingLevel _level;
		private readonly System.Collections.Generic.List<Filter> _filters;
		private readonly System.Collections.Generic.List<Handler> _handlers;
		public static Logger GetLogger(string name = "root") {
			Logger value;
			if (Logger.Loggers.TryGetValue(name, out value)) {
				return value;
			}
			value = new Logger(name);
			Logger.Loggers.Add(name, value);
			return value;
		}
		private Logger(string name) {
			this._name = name;
			this._level = LoggingLevel.Warning;
			this._filters = new System.Collections.Generic.List<Filter>();
			this._handlers = new System.Collections.Generic.List<Handler>();
		}
		public void SetLevel(LoggingLevel level) {
			this._level = level;
		}
		public void AddHandler(Handler handler) {
			this._handlers.Add(handler);
		}
		public void RemoveHandler(Handler handler) {
			this._handlers.Remove(handler);
		}
		public void AddFilter(Filter filter) {
			this._filters.Add(filter);
		}
		public void RemoveFilter(Filter filter) {
			this._filters.Remove(filter);
		}
		public void Debug(string message, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			this.Log(LoggingLevel.Debug, message, null, filePath, lineNumber, memberName);
		}
		public void Info(string message, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			this.Log(LoggingLevel.Info, message, null, filePath, lineNumber, memberName);
		}
		public void Warning(string message, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			this.Log(LoggingLevel.Warning, message, null, filePath, lineNumber, memberName);
		}
		public void Error(string message, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			this.Log(LoggingLevel.Error, message, null, filePath, lineNumber, memberName);
		}
		public void Critical(string message, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			this.Log(LoggingLevel.Critical, message, null, filePath, lineNumber, memberName);
		}
		public void Exception(Exception error, string message = "", [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			this.Log(LoggingLevel.Error, message, error, filePath, lineNumber, memberName);
		}
		public void Log(LoggingLevel level, string message, Exception error = null, [System.Runtime.CompilerServices.CallerFilePath] string filePath = "", [System.Runtime.CompilerServices.CallerLineNumber] int lineNumber = 0, [System.Runtime.CompilerServices.CallerMemberName] string memberName = "") {
			if (this.IsEnabledFor(level)) {
				var record = new LogRecord(this._name, level, filePath, lineNumber, memberName, message, error);
				if (this._filters.All(x => x.Check(record))) {
					this._handlers.ForEach(x => x.Process(record));
				}
			}
		}
		public bool IsEnabledFor(LoggingLevel level) {
			return level >= this._level;
		}
	}
	public abstract class Handler {
		public static ExceptionSetting RaiseExceptions = ExceptionSetting.Write;
		private static readonly Formatter DefaultFormatter = new Formatter();
		private LoggingLevel _level;
		private readonly System.Collections.Generic.List<Filter> _filters;
		private Formatter _formatter;
		protected Handler() {
			this._level = LoggingLevel.Warning;
			this._filters = new System.Collections.Generic.List<Filter>();
			this._formatter = null;
		}
		public void SetLevel(LoggingLevel level) {
			this._level = level;
		}
		public void SetFormatter(Formatter formatter) {
			this._formatter = formatter;
		}
		public void AddFilter(Filter filter) {
			this._filters.Add(filter);
		}
		public void RemoveFilter(Filter filter) {
			this._filters.Remove(filter);
		}
		public void Process(LogRecord record) {
			if (this.IsEnabledFor(record.Level) && this._filters.All(x => x.Check(record))) {
				lock (this) {
					this.Emit(record);
				}
			}
		}
		protected abstract void Emit(LogRecord record);
		public bool IsEnabledFor(LoggingLevel level) {
			return level >= this._level;
		}
		private Formatter SafeFormatter => this._formatter ?? Handler.DefaultFormatter;
		protected string Format(LogRecord record) {
			return this.SafeFormatter.Format(record);
		}
		protected void HandleError(LogRecord record, Exception error) {
			if (Handler.RaiseExceptions != ExceptionSetting.Pass) {
				Console.Error.WriteLine("--- Logging error ---");
				Console.Error.WriteLine(error);
				Console.Error.WriteLine($"Logged from file {record.FilePath}, line {record.LineNumber}");
				Console.Error.WriteLine($"Message: {record.Message}");
				Console.Error.WriteLine($"Created: {this.SafeFormatter.FormatTime(record)}");
				if (Handler.RaiseExceptions == ExceptionSetting.Throw) {
					throw error;
				}
			}
		}
	}
	public class StreamHandler : Handler {
		public static readonly string Terminator = Environment.NewLine;
		protected System.IO.TextWriter Stream;
		public StreamHandler(System.IO.TextWriter stream = null) {
			this.Stream = stream ?? Console.Error;
		}
		public void Flush() {
			this.Stream.Flush();
		}
		protected override void Emit(LogRecord record) {
			try {
				var message = this.Format(record);
				this.Stream.Write(message);
				this.Stream.Write(StreamHandler.Terminator);
				this.Flush();
			} catch (Exception error) {
				this.HandleError(record, error);
			}
		}
	}
	public class FileHandler : StreamHandler {
		public static readonly System.Text.Encoding DefaultEncoding = System.Text.Encoding.GetEncoding("iso-8859-1");
		protected readonly string FileName;
		private readonly System.IO.FileMode _mode;
		private readonly System.Text.Encoding _codec;
		public FileHandler(string fileName, System.IO.FileMode mode, System.Text.Encoding codec = null) : base(
			new System.IO.StreamWriter(new System.IO.FileStream(fileName, mode), codec ?? FileHandler.DefaultEncoding)) {
			this.FileName = fileName;
			this._mode = mode;
			this._codec = codec;
		}
		public void Close() {
			this.Flush();
			this.Stream.Close();
		}
		protected System.IO.StreamWriter Open() {
			return new System.IO.StreamWriter(new System.IO.FileStream(this.FileName, this._mode), this._codec ?? FileHandler.DefaultEncoding);
		}
	}
	public abstract class BaseRotatingHandler : FileHandler {
		protected Func<string, string> Namer;
		protected Action<string, string> Rotator;
		protected BaseRotatingHandler(string fileName, System.IO.FileMode mode, System.Text.Encoding codec = null) : base(
			fileName, mode, codec) {
			this.Namer = null;
			this.Rotator = null;
		}
		protected override void Emit(LogRecord record) {
			try {
				if (this.ShouldRollover(record)) {
					this.DoRollover();
				}
				base.Emit(record);
			} catch (Exception error) {
				this.HandleError(record, error);
			}
			
		}
		protected abstract bool ShouldRollover(LogRecord record);
		protected abstract void DoRollover();
		protected string GetRotationFilename(string defaultName) {
			return this.Namer == null ? defaultName : this.Namer(defaultName);
		}
		protected void Rotate(string source, string destination) {
			if (this.Rotator == null) {
				System.IO.File.Move(source, destination);
			} else if (System.IO.File.Exists(source)) {
				this.Rotator(source, destination);
			}
		}
	}
	public class RotatingFileHandler : BaseRotatingHandler {
		private readonly int _maxBytes;
		private readonly int _backupCount;
		public RotatingFileHandler(string fileName, System.IO.FileMode mode, int maxBytes = 0, int backupCount = 0,
			System.Text.Encoding codec = null) : base(fileName, mode, codec) {
			this._maxBytes = maxBytes;
			this._backupCount = backupCount;
		}
		protected override bool ShouldRollover(LogRecord record) {
			if (this._maxBytes <= 0) return false;
			var message = $"{this.Format(record)}{StreamHandler.Terminator}";
			return ((System.IO.StreamWriter) this.Stream).BaseStream.Position + message.Length >= this._maxBytes;
		}
		protected override void DoRollover() {
			this.Close();
			if (this._backupCount > 0) {
				string destination;
				foreach (var i in Enumerable.Range(1, this._backupCount - 1).Reverse()) {
					var source = this.GetRotationFilename($"{this.FileName}.{i}");
					destination = this.GetRotationFilename($"{this.FileName}.{i + 1}");
					if (System.IO.File.Exists(source)) {
						if (System.IO.File.Exists(destination)) {
							System.IO.File.Delete(destination);
						}
						System.IO.File.Move(source, destination);
					}
				}
				destination = this.GetRotationFilename($"{this.FileName}.1");
				if (System.IO.File.Exists(destination)) {
					System.IO.File.Delete(destination);
				}
				this.Rotate(this.FileName, destination);
			}
			this.Stream = this.Open();
		}
	}
	public class SmtpHandler : Handler {
		private readonly System.Net.DnsEndPoint _mailServer;
		private readonly string _fromAddress;
		private readonly System.Collections.Generic.List<string> _toAddress;
		private readonly string _subject;
		private readonly int _timeout;
		public SmtpHandler(System.Net.DnsEndPoint mailServer, string fromAddress, System.Collections.Generic.List<string> toAddress, string subject, int timeout = 1000) {
			this._mailServer = mailServer;
			this._fromAddress = fromAddress;
			this._toAddress = toAddress;
			this._subject = subject;
			this._timeout = timeout;
		}
		protected string GetSubject(LogRecord record) {
			return this._subject;
		}
		protected override void Emit(LogRecord record) {
			try {
				var message = new System.Net.Mail.MailMessage { From = new System.Net.Mail.MailAddress(this._fromAddress), Subject = this.GetSubject(record), Body = this.Format(record) };
				this._toAddress.ForEach(x => message.To.Add(new System.Net.Mail.MailAddress(x)));
				using (var client = new System.Net.Mail.SmtpClient(this._mailServer.Host, this._mailServer.Port)) {
					client.Timeout = this._timeout;
					client.Send(message);
				}
			} catch (Exception error) {
				this.HandleError(record, error);
			}
		}
	}
	public class Filter {
		private readonly string _name;
		public Filter(string name = null) {
			this._name = name;
		}
		public bool Check(LogRecord record) {
			return this._name == null || this._name == record.Name;
		}
	}
	public class StyleSettings {
		public string DefaultFormat { get; }
		public string TimeToken { get; }
		public string RegexSearch { get; }
		public string PreferredFormat { get; }
		public StyleSettings(string defaultFormat, string timeToken, string regexSearch, string preferredFormat) {
			this.DefaultFormat = defaultFormat;
			this.TimeToken = timeToken;
			this.RegexSearch = regexSearch;
			this.PreferredFormat = preferredFormat;
		}
	}
	public class Style {
		public static readonly StyleSettings Percent = new StyleSettings("%(Message)", "%(Created)", @"%\((\w+)\)", "%(Level):%(Name):%(Message)");
		public static readonly StyleSettings StringFormat = new StyleSettings("{Message}", "{Created}", @"\{(\w+)\}", "{Level}:{Name}:{Message}");
		public static readonly StyleSettings StringTemplate = new StyleSettings("${Message}", "${Created}", @"\$\{(\w+)\}", "${Level}:${Name}:${Message}");
		private readonly StyleSettings _settings;
		private readonly string _format;
		public Style(StyleSettings settings, string format = null) {
			this._settings = settings;
			this._format = format ?? settings.DefaultFormat;
		}
		public bool UsesTime => this._format.IndexOf(this._settings.TimeToken, StringComparison.Ordinal) >= 0;
		public string Format(LogRecord record, string dateFormat = null) {
			var regex = new System.Text.RegularExpressions.Regex(this._settings.RegexSearch);
			return regex.Replace(this._format, x => Style.Replace(x, record, dateFormat));
		}
		private static string Replace(System.Text.RegularExpressions.Match match, LogRecord record, string dateFormat) {
			System.Diagnostics.Debug.Assert(match.Groups.Count == 2, "one item should be captured");
			var value = Functions.GetProperty<LogRecord, object>(record, match.Groups[1].Value);
			return value is DateTime && dateFormat != null ? ((DateTime) value).ToString(dateFormat) : value.ToString();
		}
	}
	public class Formatter {
		private readonly Style _style;
		private readonly string _dateFormat;
		public Formatter(string format = null, string dateFormat = null, StyleSettings settings = null) {
			var preferredSettings = settings ?? Style.StringFormat;
			this._style = new Style(preferredSettings, format ?? preferredSettings.PreferredFormat);
			this._dateFormat = dateFormat ?? Scan.DateTimeFormat;
		}
		public string FormatTime(LogRecord record, string dateFormat = null) {
			return record.Created.ToString(dateFormat ?? this._dateFormat);
		}
		public string FormatException(LogRecord record) {
			return record.Error.ToString();
		}
		public bool UsesTime => this._style.UsesTime;
		public string FormatMessage(LogRecord record) {
			return this._style.Format(record, this._dateFormat);
		}
		public string Format(LogRecord record) {
			var message = this.FormatMessage(record);
			if (record.Error != null) {
				message += StreamHandler.Terminator + this.FormatException(record);
			}
			return message;
		}
	}
	public class LogRecord {
		public string Name { get; }
		public LoggingLevel Level { get; }
		public string FilePath { get; }
		public int LineNumber { get; }
		public string MemberName { get; }
		public string Message { get; }
		public Exception Error { get; }
		public DateTime Created { get; }
		public int ThreadId { get; }
		public string ThreadName { get; }
		public int ProcessId { get; }
		public string ProcessName { get; }
		public LogRecord(string name, LoggingLevel level, string filePath, int lineNumber, string memberName,
			string message, Exception error = null) {
			this.Name = name;
			this.Level = level;
			this.FilePath = filePath;
			this.LineNumber = lineNumber;
			this.MemberName = memberName;
			this.Message = message;
			this.Error = error;
			this.Created = DateTime.Now;
			var thread = System.Threading.Thread.CurrentThread;
			this.ThreadId = thread.ManagedThreadId;
			this.ThreadName = thread.Name;
			var process = System.Diagnostics.Process.GetCurrentProcess();
			this.ProcessId = process.Id;
			this.ProcessName = process.ProcessName;
		}
		public override string ToString() {
			return $"<{nameof(LogRecord)}: {this.Name}, {this.Level}, {this.FilePath}, {this.LineNumber}, {this.Message}>";
		}
	}
	public enum LoggingLevel {
		Debug,   // Detailed information, typically of interest only when diagnosing problems.
		Info,    // Confirmation that things are working as expected.
		Warning, // An indication that something unexpected happened, or indicative of some problem in the near future (e.g. ‘disk space low’). The software is still working as expected.
		Error,   // Due to a more serious problem, the software has not been able to perform some function.
		Critical // A serious error, indicating that the program itself may be unable to continue running.
	}
	public enum ExceptionSetting {
		Pass,	// Do nothing about the problem.
		Write,	// Record problem on standard error.
		Throw	// Propagate the exception once written.
	}
	public class Scan {
		public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
    }
	public static class Functions {
		public static TOut GetProperty<TIn, TOut>(TIn value, string name) {
			return (TOut) Functions.NotNull(value.GetType().GetProperty(name), $"{name} is not available").GetValue(value);
		}
		public static T NotNull<T>(T value, string message = null) {
			if (value == null) {
				throw new InvalidOperationException(message ?? $"{nameof(value)} may not be null");
			}
			return value;
		}
    }
