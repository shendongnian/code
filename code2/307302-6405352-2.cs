    interface IBase {
        void Act();
    }
    interface IAction1 : IBase {
        void Act();
    }
    interface IAction2 : IBase {
        void Act();
    }
    class MyClass : IAction1, IAction2 {
        public void Act() {
            Console.WriteLine( "satisfies IBase.Act()" );
        }
        void IAction1.Act() {
            Console.WriteLine( "IAction1.Act()" );
        }
        void IAction2.Act() {
            Console.WriteLine( "IAction2.Act()" );
        }
        static void Main( string[] args ) {
            MyClass cls = new MyClass();
            cls.Act();
            IAction1 a = cls;
            a.Act();
            IAction2 b = cls;
            b.Act();
            Console.ReadKey();
        }
    }
