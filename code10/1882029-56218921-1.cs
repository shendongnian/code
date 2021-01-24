public class ItemComponent : ComponentBase
{
    public async Task<ItemModel[]> GetItems()
    {
        ItemModel[] ItemList;
        HttpClient Http = new HttpClient();
        ItemList = await Http.GetJsonAsync<ItemModel[]>("api/Item/GetItems");
        return ItemList;
    }
}
The article is a little out of date as `BlazorComponent` was renamed a while ago.
Just make sure to move all of the code you have in the `functions` block of your view into the base class as mixing the two approaches can have odd side effects.
