@page "/Item"
@inherits ItemComponent
@if (ItemList != null)
{
    <table class="table">
        <thead>
            <tr>
                <th>ID</th>
                <th>Name</th>
                <th>Category</th>
                <th>Metal</th>
                <th>Price</th>
                <th>Quantity</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in ItemList)
            {
                <tr>
                    <td>@item.ID</td>
                    <td>@item.Name</td>
                    <td>@item.Category</td>
                    <td>@item.Metal</td>
                    <td>@item.Price</td>
                    <td>@item.Quantity</td>
                </tr>
            }
        </tbody>
    </table>
}
public class ItemComponent : ComponentBase
{
    [Inject] HttpClient HttpClient { get; set; }
    public List<ItemModel> ItemList;
    protected override async Task OnInitAsync()
    {
        ItemList = await GetItems();
    }
    public async Task<List<ItemModel>> GetItems()
    {
        return await HttpClient.GetJsonAsync<List<ItemModel>>("api/Item/GetItems");
    }
}
This should work as expected as long as your backend is setup correctly (Example: CORS).
