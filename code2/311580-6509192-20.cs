    namespace CSharp {
        public static class PI {
            public static double compute() {
                CLI.PI.compute(
                    percentCompleted => System.Console.WriteLine(
                        percentCompleted.ToString() + "% completed."
                    )
                );
            }
        }
    }
