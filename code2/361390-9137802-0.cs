        static void Main() {
            var task = Task<double>.Factory.StartNew(Calc1)
                .OrIfException(Calc2)
                .OrIfException(Calc3)
                .OrIfException(Calc4);
            Console.WriteLine(task.Result); // shows "3" (the first one that passed)
        }
        static double Calc1() {
            throw new InvalidOperationException();
        }
        static double Calc2() {
            throw new InvalidOperationException();
        }
        static double Calc3() {
            return 3;
        }
        static double Calc4() {
            return 4;
        }
    }
    static class A {
        public static Task<T> OrIfException<T>(this Task<T> task, Func<T> nextOption) {
            return task.ContinueWith(t => t.Exception == null ? t.Result : nextOption(), TaskContinuationOptions.ExecuteSynchronously);
        }
    }
