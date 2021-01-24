    using System;
    namespace FooBar {
        class Program {
            static void Main(string[] args) {
               Foo test = new Foo();
               test.barFoo();
            }
            class Foo {
                string _Bar;
                public string Bar {
                    get {
                        if (_Bar == null) {
                            _Bar = "FooBar";
                        }
                        return _Bar;
                    }
                    set {
                        _Bar = value;
                    }
                }
                public void barFoo() {
                    _Bar = null;
                    if (_Bar != null) {
                        throw new Exception("_Bar is not null.");
                    }
                }
                public override string ToString() {
                    return Bar;
                }
            }
        }
    }
