    public class ProductViewModel
    {
        public ProductDTO Product { get; set; }
        public List&lt;ProductImageViewModel&gt; Images { get; set; }
    }
    public class ProductImageViewModel
    {
        public ProductImageDTO ProductImage { get; set; }
        // since this ProductImageViewModel will be <b>embedded as List&lt;ProductImageViewModel&gt;</b>
        //     make sure it <b>has no IFormFile property directly</b>
        <strike>public IFormFile ImageFile { get; set; }</strike>
        <b>public IFormFileWrapper Image{ get; set; }</b>  
         
        // a dummy wrapper
        <b>public class IFormFileWrapper</b>
        <b>{</b>
        <b>    public IFormFile File { get; set;}</b>
        <b>}</b>
    }
