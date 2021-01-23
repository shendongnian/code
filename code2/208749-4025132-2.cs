    class MyImage
    {
       public string Name {get; set;}
       public string Url {get; set;}
       public List<string> OtherInfo {get; set;}
    }
    
    ...
    public List<MyImage> MyImages = new List<MyImage>();
    
    ...
    var img = new MyImage {"Name","http://www.example.com"});
    img.OtherInfo.Add("Info1");
    img.OtherInfo.Add("Info2");
    img.OtherInfo.Add("Info3");
    
    string html = "";
    foreach(var image in MyImages)
    {
       // Access image data and write it out. etc.
       html+= String.Format("<div>{1}{2}</div>",image.Name, image.Url);
       foreach(var info in image.OtherInfo)
       {
          html+= "<div>" + info + "</div";
       }
    }
    
    // Write out your code to a literal, placeholder, etc.
    MyLiteralControl.Text = html;
