    [LayoutRenderer("IndentationLayout")]
    public sealed class IndentationLayoutRenderer : LayoutRenderer
    {
        // Value to substract from stack count
        private uint _ignore = 12;
        // Value to pad with.
        private string _ipadding = "| ";
        /// <summary>Set the number of (top) stackframes to ignore</summary>
        public uint Ignore
        {
            get { return _ignore; }
            set { _ignore = value; }
        }
        /// <summary>Set the padding value</summary>
        public string IndentationPadding
        {
            get { return _ipadding; }
            set { _ipadding = value; }
        }
        protected override void Append(StringBuilder builder, LogEventInfo ev)
        {
            // Get current stack depth, insert padding chars.
            StackTrace st = new StackTrace();
            long indent = st.FrameCount;
            indent = indent > _ignore ? indent - _ignore : 0;
            for (int i = 0; i < indent; ++i)
            {
                builder.Append(_ipadding);
            }
        }
    }
