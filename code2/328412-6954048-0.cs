    namespace Test
    {
    public partial  class attributeType: ICommonFields
    {
        
    }
    public partial class ts_attributeType : ICommonFields
    {
    }
    public interface ICommonFields
    {
        string id { get; set; }
        string type { get; set; }
    }
}
        private static void FieldInfo<T>(T row)
            where T : ICommonFields
                                                
        {
            Console.Write(((T)row).id + "/" + (((T)row).type ?? "NULL") + "/");
        }
