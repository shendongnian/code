    public class CreateOrderViewModel
    {
       public int OrderId { get; set; }
       public DateTime OrderDate { get; set; }
       public int SelectedProductId { get; set; }
       public IEnumerable<SelectListItem> Products { get; set; }
    }
