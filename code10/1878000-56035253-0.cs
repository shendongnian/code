    public class Product{
     public int Id { get; set; }
     
     public string Name { get; set; }
     [JsonIgnore]
     public byte[] Image { get; set }
    }
    // controller 
    public List<Product> Get(){
     return db.Products.ToList();
    }
    public FileResult GetImage(int id){
      var img = db.Products.First(x=> x.Id == id).Image;
      return File(img, System.Net.Mime.MediaTypeNames.Application.Octet, "test");
    }
    /// now lets say that you present your product with js as an example
    var products = getProductByAjax();
    products.forEach(x=> {
    // and here is the image 
    var img = "<img src=/Home/GetImage?id="+x.Id+" />";
    })
