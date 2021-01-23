    public class EmpresaGridModel
    {
        public string Cgc { get; set; }
        public string CgcFormatted 
        {
            return FormataCgc(this.Cgc);
        }
        //properties for the other fields will have to be created as well obviously
    }
