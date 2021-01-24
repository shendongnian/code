public class UploadPayload{
    public IList&lt;Upload&gt; Uploads{get;set;}
    public class IFormFileWrapper {
        public IFormFile File { get; set; }
    }
    public class Upload
    {
        // See https://github.com/aspnet/Mvc/issues/8782
        <strike>public IFormFile File { get; set; }</strike>
        public IFormFileWrapper CodigoFile { get; set; }
        public string CodigoVendaArquivo { get; set; }
        public string CodigoClienteArquivo { get; set; }
        public string Checkbox { get; set; }
    }
}
