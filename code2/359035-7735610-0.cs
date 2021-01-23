        public interface IA {
            int Prop { get; }
            void F();
        }
        public abstract class ABase : IA {
            public virtual int Prop
            {
                get { return 0; }
            }
            public abstract void F();
        }
        public class A : ABase
        {
            public override void F() { }
        }
