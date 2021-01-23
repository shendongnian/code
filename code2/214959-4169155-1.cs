    public class FormDebugMetrics : IEnumerable<string> {
        // details elided
        public string DebugMetrics_Top { get; set; }
        public string DebugMetrics_Middle { get; set; }
        public string DebugMetrics_Bottom { get; set; }
        public IEnumerator<string> GetEnumerator() {
            yield return this.DebugMetrics_Top;
            yield return this.DebugMetrics_Middle;
            yield return this.DebugMetrics_Bottom;
        }
        IEnumerator IEnumerator.GetEnumerator() {
            return GetEnumerator();
        }
    }
