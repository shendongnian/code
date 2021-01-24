    namespace ConsoleApp2 {
        using System;
        using System.Collections.Generic;
        using System.Dynamic;
        using System.Linq;
        using System.Linq.Dynamic;
    
        class Program {
            static void Main(string[] args) {
                var dynamics = new D[] {
                    new D(new Person { Age = 1 }),
                    new D(new Person { Age = 50 }),
                    new D(new Person { Age = 100 })
                };
    
                var first = dynamics[0].Age;
    
                var second = dynamics.Where(x => x.Age > 45);
    
                var filter = System.Linq.Dynamic.DynamicExpression.ParseLambda<D, bool>("Age > 45");
    
                var third = dynamics.Where(filter.Compile());
            }
    
            public class D : DynamicObject {
                Person _p;
    
                public D(Person p) {
                    _p = p;
                }
    
                public Type Type => this._p.GetType();
    
                public override IEnumerable<string> GetDynamicMemberNames() {
                    return new[] { "Age" };
                }
    
                public override bool TryGetMember(GetMemberBinder binder, out object result) {
                    var name = binder.Name;
                    if (name == "Age") {
                        result = _p.Age;
                        return true;
                    }
    
                    result = null;
                    return false;
                }
    
                public int Age => _p.Age;
            }
    
            public class Person {
                public int Age { get; set; }
            }
        }
    }
