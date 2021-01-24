`html
<!-- use ID as the target property name in the select element -->
<form method="get">
    <select asp-for="ID" asp-items=@Model.pvalues>
        <option value="" selected>Select a value..</option>
    </select>
    <input type="submit" value="Compare" />
</form>
`
On the backend you can catch the value of the select either by using the parameter in get method:
`cs
public void OnGet(int ID)
{
    // ....
}
`
Or using a property name and adding binding attribute:
`cs
[BindProperty(SupportsGet = true)]
public int ID { get; set; };
public void OnGet()
{
    // ...
}
`
