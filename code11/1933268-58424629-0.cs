    //// c#
    public class ToyType
    {
    	public string TypeName {get; set;}
    	public string TypeClass {get; set;}
    }
    
    public List<ToyType> toyTypes {get; set;}
    
    //// razor
    @foreach (var toyType in Model.toyTypes)
    {
    	<input type="submit" asp-for="typePicked" class="btn btn-outline-secondary @toyType.TypeClass" value="@toyType.TypeName" />
    }
