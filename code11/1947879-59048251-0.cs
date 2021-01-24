    public class MyModel
        {
            public string Number { get; set; }
        }
    
    var model = new MyModel { Number = "+3194949494" };            
    model.Number = model.Number != null ? model.Number.Insert(3, " ").Insert(7, " ") : string.Empty;
    
    <h1>@Html.DisplayFor(m => m.Number)</h1>
