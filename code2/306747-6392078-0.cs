    public class A {
        public string Prop1 {get;set;}
        public int? Prop2 {get;set;}
        public static A Merge(A a, A b) {
            var res = new A();
            //res.Prop = b.Prop unless b.Prop is null, in which case res.Porp = a.Prop
            res.Prop1 = b.Prop1 ?? a.Prop1;
            res.Prop2 = b.Prop2 ?? a.Prop2;
            return res;
        }
    }
    var a = new A() {Prop1 = "A", Prop2 = 1};
    var b = new A() {Prop1 = "B"};
    var c = A.Merge(a,b);
