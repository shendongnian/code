    namespace Test
    {
        public partial  class attributeType: IAttributeRow {}
        public partial class ts_attributeType : IAttributeRow {}
        public interface ICommonFields
        {
            string id { get; set; }
            string type { get; set; }
        }
    }
        private static void FieldInfo<T>(T row)
            where T : IAttributeRow 
                                                
        {
            Console.Write(((T)row).id + "/" + (((T)row).type ?? "NULL") + "/");
        }
