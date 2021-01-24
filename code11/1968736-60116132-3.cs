      @model Dashboard.Controllers.TestModel
    
    @{
    
        var testObject = new Dashboard.Controllers.TestModel();
    }
    
    
    @foreach (var item in Model.TestList)
    {
        <h5>@item.S</h5>
    }
    
    
    <input type="hidden" value="@testObject.AnyMethod()" />
