    interface IProblemFactory<T> where T : IProblem<T> 
    {
        T Create();
    }
---
    class ArithmeticProblemFactory : IProblemFactory<Arithmetic> 
    {
        private Tuple<int, decimal, decimal> condition;
        public ArithmeticProblemFactory(Tuple<int, decimal, decimal> condition) {
            this.condition = conditionl
        }
        Arithmetic IProblemFactory<Arithmetic>.Create() {
            ...
        }
    }
