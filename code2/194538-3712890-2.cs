    public interface IKing<T> where T:Result{
        T Get();
    }
    public class King<T> : IKing<T>
       public abstract T Get();
    }
    public class KingA : King<ResultB> {
        public override ResultA Get(){
            return new ResultA();
        }
    }
    public class KingB : King<ResultB> {
        public override ResultB Get(){
            return new ResultB();
        }
    }
