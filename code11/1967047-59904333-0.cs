    public enum MasterSectionEnum
    {
        LOCALCODE,
        NATIONALCODE
    }
    
    public sealed class LocalCode { }
    public sealed class NationalCode { }
    
    public sealed class Program
    {
        private static readonly Dictionary<MasterSectionEnum, Func<Guid, Task>> Dictionary
            = new Dictionary<MasterSectionEnum, Func<Guid, Task>>();
    
        static Program()
        {
            Dictionary[MasterSectionEnum.LOCALCODE] = UpdateRevision<LocalCode>;
            Dictionary[MasterSectionEnum.NATIONALCODE] = UpdateRevision<NationalCode>;
        }
    
        public static async Task SetRequestStage(MasterSectionEnum masterSectionEnum)
        {
            await Dictionary[masterSectionEnum].Invoke(Guid.NewGuid());
        }
    
        private static Task UpdateRevision<T>(Guid id) where T : class
        {
            Console.WriteLine(typeof(T));
            return Task.CompletedTask;
        }
    
        public static async Task Main()
        {
            await SetRequestStage(MasterSectionEnum.LOCALCODE);
            await SetRequestStage(MasterSectionEnum.NATIONALCODE);
    
            Console.ReadKey();
        }
    }
