csharp
public class MyPageProductVM {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int ProductCategoryID { get; set; }
}
public class MyPageProductCategoryVM {
    public int ProductCategoryID { get; set; }
    public string ProductCategoryName { get; set; }
    public IList<MyPageProductVM> { get; set; }
}
Your view can now use `IList<MyPageProductCategoryVM>` as the model. You could ofcourse go ahead and create another `MyPageVM`  class to contain the list and any additional fields, and make the view use `MyPageVM` as the model.
I believe this is not what you're after, but for completeness, another option is to denormalize the domain models:
public class MyPageProductVM {
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public int ProductCategoryID { get; set; }
    public int ProductCategoryID { get; set; }
    public string ProductCategoryName { get; set; }
}
---
You can use a library like AutoMapper or Mapster to map the VMs with the domain models.
