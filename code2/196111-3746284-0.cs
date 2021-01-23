    [Test]
            public void ActionsTest()
            {
                var parent = new Parent();
                parent.Child.RaiseCallFromParent();
                parent.Child.RaiseCallInParent();
            }
    
            public class Parent
            {
                private readonly Child _child = new Child();
    
                public Parent()
                {
                    Child.ActionToCallMethodFromParent = methodCalledFromChild;
                    Child.ActionToBeCalledInParent += actionCalledInParent;
                }
    
                public Child Child
                {
                    get { return _child; }
                }
    
                private void actionCalledInParent()
                {
                    Console.WriteLine("It is called in parent on child initiative.");
                }
    
    
                private void methodCalledFromChild()
                {
                    Console.WriteLine("It is called from child");
                }
            }
    
            public class Child
            {
                public Action ActionToCallMethodFromParent;
                public Action ActionToBeCalledInParent;
    
                public void RaiseCallFromParent()
                {
                    //This works in cases when you need to consume something from Parent but here you cannot take it directly
                    if (ActionToCallMethodFromParent != null)
                        ActionToCallMethodFromParent();
                }
    
                public void RaiseCallInParent()
                {
                    //This works like an event
                    if (ActionToBeCalledInParent != null)
                        ActionToBeCalledInParent();
                }
            }
