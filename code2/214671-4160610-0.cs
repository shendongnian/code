    public class ConcreteEnum : Abstract {
        public void DoSomething( Enum e ) { 
            base.DoSomething( "String somehow extracted from enum");
        }
        public override void DoSomething( string s ) {
            // Validate s, then do something with it
        }
    }
