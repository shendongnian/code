    using System;
    using System.Dynamic;
    using System.Text.RegularExpressions;
    class DynamicParameter : DynamicObject {
        object[] _p;
        public DynamicParameter(params object[] p) {
            _p = p;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            Match m = Regex.Match(binder.Name, @"^p(\d+)$");
            if (m.Success) {
                int index = int.Parse(m.Groups[1].Value);
                if (index < _p.Length) {
                    result = _p[index];
                    return true;
                }
            }
            return base.TryGetMember(binder, out result);
        }
    }
    class Program {
        static void Main(string[] args) {
            dynamic d1 = new DynamicParameter(123, "test");
            Console.WriteLine(d1.p0);
            Console.WriteLine(d1.p1);
        }
    }
