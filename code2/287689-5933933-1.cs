    public class InvertedScrollBar : VScrollBar
    {
        /// <summary>
        /// Gets or sets the "inverted" scrollbar value.
        /// </summary>
        /// <value>The inverted value.</value>
        public int InvertedValue
        {
            get
            {
                int offset = this.Value - this.Minimum;
                return this.Maximum - offset;
            }
            set
            {
                int offset = this.Maximum - value;
                this.Value = this.Minimum + offset;
            }
        }
    }
