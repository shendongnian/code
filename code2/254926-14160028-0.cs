    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Text;
    public class TextWrittenEventArgs : EventArgs {
	    public string Text { get; private set; }
	    public TextWrittenEventArgs(string text) {
		    this.Text = text;
	    }
    }
    public class DebugMessages {
      StringBuilder _debugBuffer = new StringBuilder();
      public DebugMessages() {
        Debug.OnWrite += delegate(object sender, TextWrittenEventArgs e) { _debugBuffer.Append(e.Text); };
      }
      public override string ToString() {
        return _debugBuffer.ToString();
      }
    }
    public static class Debug {
      public delegate void OnWriteEventHandler(object sender, TextWrittenEventArgs e);
      public static event OnWriteEventHandler OnWrite;
      public static void Write(string text) {
        TextWritten(text);
      }
      public static void WriteLine(string text) {
        TextWritten(text + System.Environment.NewLine);
      }
      public static void Write(string text, params object[] args) {
        text = (args != null ? String.Format(text, args) : text);
        TextWritten(text);
      }
      public static void WriteLine(string text, params object[] args) {
        text = (args != null ? String.Format(text, args) : text) + System.Environment.NewLine;
        TextWritten(text);
      }
      private static void TextWritten(string text) {
        if (OnWrite != null) OnWrite(null, new TextWrittenEventArgs(text));
      }
    }
