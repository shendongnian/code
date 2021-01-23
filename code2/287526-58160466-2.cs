namespace System {
  public static class ExtensionMethods {
    public static string FullMessage(this Exception ex) {
      if (ex is AggregateException) return (ex as AggregateException).InnerExceptions.Aggregate("[ ", (total, next) => $"{total}[{next.FullMessage()}] ") + "]";
      var msg = ex.Message.Replace(", see inner exception.", "").Trim();
      return ex.InnerException is null ? msg : $"{msg} [{ex.InnerException.FullMessage()}]";
    }
  }
}
This "pretty prints" all inner exceptions
