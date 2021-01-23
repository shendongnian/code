    public class CssTextWriter
    {
        public CssTextWriter(TextWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            this.Writer = writer;
            this.Initialize();
        }
        /// <summary>
        /// Gets the writer.
        /// </summary>
        /// <value>
        /// The writer.
        /// </value>
        public TextWriter Writer { get; private set; }
        /// <summary>
        /// Gets or sets the internal CSS text writer.
        /// </summary>
        /// <value>
        /// The internal CSS text writer.
        /// </value>
        private object InternalCssTextWriter
        {
            get;
            set;
        }
         public void WriteBeginCssRule(string selector)
        {
            this.InternalCssTextWriter.InvokeMethod("WriteBeginCssRule", new[] { selector });
        }
        public void WriteEndCssRule()
        {
            this.InternalCssTextWriter.InvokeMethod("WriteEndCssRule");
        }
        public void WriteAttribute(string name, string value)
        {
            this.InternalCssTextWriter.InvokeMethod("WriteAttribute", new[] { name, value }, new Type[] { typeof(string), typeof(string) });
        }
        public void Write(string value)
        {
            this.InternalCssTextWriter.InvokeMethod("Write", new[] { value }, new Type[] { typeof(string) });
        }
        public void WriteAttribute(HtmlTextWriterStyle key, string value)
        {
            this.InternalCssTextWriter.InvokeMethod("WriteAttribute", new object[] { key, value }, new Type[] { typeof(HtmlTextWriterStyle), typeof(string) });
        }
        private void Initialize()
        {
            Type internalType = typeof(System.Web.UI.HtmlTextWriter).Assembly.GetType("System.Web.UI.CssTextWriter");
            ConstructorInfo ctor = internalType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)[0];
            this.InternalCssTextWriter = ctor.Invoke(new[] { this.Writer });
        }
    }
