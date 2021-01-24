    using System;
    using System.Reactive.Linq;
    using NUnit.Framework;
    using ReactiveUI;
    using ReactiveUI.Fody.Helpers;
    
    namespace Testy {
        [TestFixture]
        public class Test {
            [Test]
            public void State_ChangesToChanged_PropertyChanged() {
                var _item = new MyTest();
                _item.Surname = "Testname";
                Assert.AreEqual(Statetype.Changed, _item.State);
            }
        }
    
        public enum Statetype {
            Added,
            Changed,
            Deleted,
            Detached,
            Unchanged
        }
    
        public abstract class StateBase : ReactiveObject {
            protected StateBase() {
                State = Statetype.Unchanged;
    
                Changed
                    .Select(prop => prop.PropertyName)
                    .Subscribe(
                        name => {
                            UpdateZustand(name);
                            Console.WriteLine(name);
                        });
            }
    
            protected void UpdateZustand(string propertyName) {
                if (State == Statetype.Unchanged)
                    State = Statetype.Changed;
            }
    
            [Reactive]
            public Statetype State { get; set; }
        }
    
        public class MyTest : StateBase {
            [Reactive]
            public string Name { get; set; }
    
            [Reactive]
            public string Surname { get; set; }
        }
    }
