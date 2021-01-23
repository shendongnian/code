    // model class
    public class CostModel {
      [DisplayFormat(DataFormatString = "{0:0.00}")]
      public decimal Cost {get;set;}
    }
    
    // action method
    public ActionResult Cost(){
      return View(new CostModel{ Cost=12.3456})
    }
    
    // Cost view cshtml
    @model CostModel
    
    <div>@Html.DisplayFor(m=>m.Cost)</div>
    <div>@Html.EditorFor(m=>m.Cost)</div>
    
    // rendering html
    <div>12.34</div>
    <div><input class="text-box single-line" id="Cost" name="Cost" type="text" value="12.34" /></div>
