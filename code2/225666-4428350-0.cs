    public class FileCompareLastwritetime
            : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo> {
        public FileCompareLastwritetime() { }
        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2) {
            return ToMinute(f1.LastWriteTime) == ToMinute(f2.LastWriteTime);
        }
        public int GetHashCode(System.IO.FileInfo fi) {
            return ToMinute(fi.LastWriteTime).GetHashCode();
        }
        static DateTime ToMinute(DateTime value) {
            return new DateTime(value.Year, value.Month, value.Day,
                     value.Hour, value.Minute, 0, value.Kind);
        }
    }
