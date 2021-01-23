    using System.Runtime.CompilerServices;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Attributes.Exporters;
    using BenchmarkDotNet.Attributes.Jobs;
    using BenchmarkDotNet.Running;
    [MemoryDiagnoser, ClrJob, CoreJob, MarkdownExporterAttribute.StackOverflow]
    public class Program
    {
        public static void Main() => BenchmarkRunner.Run<Program>();
        [Benchmark]
        public int ViaExplicitCast()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                sum += ((IValGetter)new ValGetter(i)).GetVal();
            }
            return sum;
        }
        [Benchmark]
        public int ViaConstrainedGeneric()
        {
            int sum = 0;
            for (int i = 0; i < 1000; i++)
            {
                sum += GetVal(new ValGetter(i));
            }
            return sum;
        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static int GetVal<T>(T val) where T : IValGetter => val.GetVal();
        public interface IValGetter { int GetVal(); }
        public struct ValGetter : IValGetter
        {
            public int _val;
            public ValGetter(int val) => _val = val;
            [MethodImpl(MethodImplOptions.NoInlining)]
            int IValGetter.GetVal() => _val;
        }
    }
