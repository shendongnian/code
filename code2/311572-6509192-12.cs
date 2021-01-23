    namespace CSharp {
        public sealed class PI : CLI.PI {
            protected override void progress(int percentCompleted) {
                System.Console.WriteLine(
                    percentCompleted.ToString() + "% completed."
                );
            }
        }
    }
