    class Foo {
        public Foo() {
            m_Field1Name = new Lazy<string>(() => GetVariableName(() => Field1));
            m_Field2Name = new Lazy<string>(() => GetVariableName(() => Field2));
        }
        public int Field1 { get; set; }
        public int Field2 { get; set; }
        public string Field1Name {
            get {
                return m_Field1Name.Value;
            }
        }
        readonly Lazy<string> m_Field1Name;
        public string Field2Name {
            get {
                return m_Field2Name.Value;
            }
        }
        readonly Lazy<string> m_Field2Name;
        public static string GetVariableName<T>(Expression<Func<T>> expression) {
            var body = expression.Body as MemberExpression;
            return body.Member.Name;
        }
    }
