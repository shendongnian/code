    using System;
    
    public interface IMarcas
    {
        string TxtMarca { get; set; }
    }
    
    public class BaseQuestao : IMarcas
    {
        public string TxtMarca
        {
            get;
            set;
        }
    }
    
    class Test
    {
        static void Main()
        {
            BaseQuestao bs = new BaseQuestao();
            IMarcas brand =  bs as IMarcas;
            if (brand != null)
            {
                brand.TxtMarca = "voila";
                Console.WriteLine("Done");
            }
        }
    }
