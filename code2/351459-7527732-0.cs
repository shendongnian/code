    class CellInfo {
        public string Title {get; set; }
        public string FormatString {get; set; }
        public Func<Person, object> EvalExpression { get; set; }
    }
