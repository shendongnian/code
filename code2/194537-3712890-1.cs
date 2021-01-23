    public interface IKing<T> where T:Result{
        T Get();
    }
    public class KingA {
        public King<ResultA>(){
            return new ResultA();
        }
    }
    public class KingB {
        public King<ResultB>(){
            return new ResultB();
        }
    }
