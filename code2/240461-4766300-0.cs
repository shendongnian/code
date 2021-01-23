    using System;
    using System.Dynamic;
    using System.Linq.Expressions;
    
    namespace ConsoleApplication10 {
        class Program {
            static void Main(string[] args) {
                dynamic dynamicObj = new MyDynamicObject(new TestPlugin());
                dynamicObj.Foo();
                dynamicObj.Bar();
                Console.ReadLine();
            }
    
        }
    
        public class TestPlugin {
            public void Foo() {
                Console.WriteLine("TestPlugin Foo");
            }
    
            public void Bar() {
                Console.WriteLine("TestPlugin Bar");
            }
        }
    
        class MyDynamicObject : IDynamicMetaObjectProvider {
            internal readonly object[] _plugins;
    
            public void Foo() {
                Console.WriteLine("MyDynamicObject Foo");
            }
    
            public void Bar() {
                Console.WriteLine("MyDynamicObject Bar");
            }
    
            public MyDynamicObject(params object[] plugins) {
                _plugins = plugins;
            }
    
            class Meta : DynamicMetaObject {
                public Meta(Expression parameter, BindingRestrictions restrictions, MyDynamicObject self)
                    : base(parameter, restrictions, self) {
                }
    
                public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args) {                
                    // get the default binding the language would return if we weren't involved
                    // This will either access a property on MyDynamicObject or it will report
                    // an error in a language appropriate manner.
                    DynamicMetaObject errorSuggestion = binder.FallbackInvokeMember(this, args);
    
                    // run through the plugins and replace our current rule.  Running through
                    // the list forward means the last plugin has the highest precedence because
                    // it may throw away the previous rules if it succeeds.
                    for (int i = 0; i < Value._plugins.Length; i++) {
                        var pluginDo = DynamicMetaObject.Create(Value._plugins[i],
                            Expression.Call(
                                typeof(MyDynamicObjectOps).GetMethod("GetPlugin"),
                                Expression,
                                Expression.Constant(i)
                            )
                        );
    
                        errorSuggestion = binder.FallbackInvokeMember(pluginDo, args, errorSuggestion);                    
                    }
    
                    // Do we want DynamicMetaObject to have precedence?  If so then we can do
                    // one more bind passing what we've produced so far as the rule.  Or if the
                    // plugins have precedence we could just return the value.  We'll do that
                    // here based upon the member name.
    
                    if (binder.Name == "Foo") {
                        return binder.FallbackInvokeMember(this, args, errorSuggestion);
                    }
    
                    return errorSuggestion;
                }
    
                public new MyDynamicObject Value {
                    get {
                        return (MyDynamicObject)base.Value;
                    }
                }
            }
    
    
    
            #region IDynamicMetaObjectProvider Members
    
            public DynamicMetaObject GetMetaObject(System.Linq.Expressions.Expression parameter) {
                return new Meta(parameter, BindingRestrictions.Empty, this);
            }
    
            #endregion
        }
    
        public static class MyDynamicObjectOps {
            public static object GetPlugin(object myDo, int index) {
                return ((MyDynamicObject)myDo)._plugins[index];
            }
        }
    }
