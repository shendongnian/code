    public class MyWidgetFormModel()
    {
       public string Name { get; set; }
       public string Price { get; set; }
       public MapFromDAL(DAL.Widget widget)
       {
          this.Name = widget.Name;
          this.Price = widget.Price;
       }
    }
