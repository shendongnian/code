    //-----------------------------------------------------------------------------
    // <copyright file="Program.cs" company="DCOM Productions">
    //     Copyright (c) DCOM Productions.  All rights reserved.
    // </copyright>
    //-----------------------------------------------------------------------------
    namespace AbstractClassExample {
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        class Program {
            /// <summary>
            /// Example abstract base class
            /// </summary>
            public abstract class FooClass {
                /// <summary>
                /// Abstract Method
                /// </summary>
                public abstract void abstractFoo();
                /// <summary>
                /// Virtual Method
                /// </summary>
                public virtual void virtualFoo() {
                    // Todo
                }
                /// <summary>
                /// Normal Method
                /// </summary>
                public void Foo() {
                    // Todo
                }
            }
            public class FooDeriver : FooClass {
                /// <summary>
                /// Implements base.abstractFoo
                /// </summary>
                public override void abstractFoo() {
                    throw new NotImplementedException();
                }
                /// <summary>
                /// Overrides base.virtualFoo
                /// </summary>
                public override void virtualFoo() {
                    base.virtualFoo();
                }
                /// <summary>
                /// Compiler ErrorError	1
                /// cannot override inherited member 'ConsoleApplication1.Program.FooClass.Foo()' because it is not marked virtual, abstract, or override
                /// </summary>
                public override void Foo() {
                    throw new NotImplementedException();
                }
            }
            static void Main(string[] args) {
                // Program code
            }
        }
    }
