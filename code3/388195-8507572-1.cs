    class LookupTableItem {
        private string Text;
        private object Value;
        public LookupTableItem(string Text, object Value) {
            this.Text = Text;
            this.Value = Value;
        }
        public override string ToString() {
            return Text;
        }
        public object GetValue() {
            return Value;
        }
    }
