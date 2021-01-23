    public abstract class AbstractTextWriter : TextWriter {
        protected abstract void WriteString(string value);
        public override Encoding Encoding { get { return Encoding.Unicode; } }
        public override void Write(char[] buffer, int index, int count) {
            WriteString(new string(buffer, index, count));
        }
        public override void Write(char value) {
            WriteString(value.ToString(FormatProvider));
        }
        public override void Write(string value) { WriteString(value); }
        //subclasses might override Flush, Dispose and Encoding
    }
    public class DelegateTextWriter : AbstractTextWriter {
        readonly Action<string> OnWrite;
        readonly Action OnClose;
        static void NullOp() { }
        public DelegateTextWriter(Action<string> onWrite, Action onClose = null) { 
            OnWrite = onWrite; 
            OnClose = onClose ?? NullOp; 
        }
        protected override void WriteString(string value) { OnWrite(value); }
        protected override void Dispose(bool disposing) { 
            OnClose(); base.Dispose(disposing); 
        }
    }
