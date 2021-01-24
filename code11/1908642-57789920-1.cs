    /// <summary>
    /// View model of a single file segment, which is represented with
    /// a vertical line. The changeable parts of the line are stored here
    /// and are directly derived from the state of the segment in the
    /// constructor (ToolTip, Color and the upper Y coordinate of the line)
    /// </summary>
    public class SegmentViewModel
    {
        private const int YTopEof=0;
        private const int YTopIntermediate=3;
        public string ToolTip { get; set; }
        public Brush Stroke { get; set; }
        public int YTop { get; set; }
        /// <summary>
        /// Derive appearance of the line from the business data received from queue
        /// if we already received data for the segment.
        /// </summary>
        /// <param name="fromQ">our knowledge about the segment state</param>
        public SegmentViewModel(SegmentState fromQ)
        {
            var sb = new StringBuilder();
            sb.Append("Seg ");
            sb.Append(fromQ.Number);
            if (fromQ.IsInMemory)
                sb.Append(", in memory");
            if (fromQ.IsOnDisk)
                sb.Append(", on disk");
            if (!fromQ.IsComplete)
                sb.Append(", INCOMPLETE!!!");
            ToolTip = sb.ToString();
            Color col;
            if (!fromQ.IsComplete)
                col = Colors.Magenta;
            else if (fromQ.IsInMemory)
                col = fromQ.IsOnDisk ? Colors.Black : Colors.Green;
            else
                col = fromQ.IsOnDisk ? Colors.RoyalBlue : Colors.Brown;
            Stroke = new SolidColorBrush(col);
            YTop = fromQ.EndOfFile ? YTopEof : YTopIntermediate;
        }
        /// <summary>
        /// This constructor is for segments that we did not receive so far.
        /// </summary>
        /// <param name="segmentNumber">We only know that we expect data from this index.</param>
        public SegmentViewModel(int segmentNumber)
        {
            ToolTip = $"Seg {segmentNumber} not yet seen";
            YTop = YTopIntermediate;
            Stroke = new SolidColorBrush(Colors.LightGray);
        }
