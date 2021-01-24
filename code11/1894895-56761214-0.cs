cshtml
@model IEnumerable<IGrouping<DateTime, FooViewModel>>
@if (Model.Any())
{
    /*
     * Since we've checked there are groupings, you can just use .First() to get 
     * the first group.
     *
     * .Key will give you the key you use to group things by. In this case, it's 
     * DateTime.
     *
     * Since there are groupings, there must be elements in the group so it's safe 
     * to use .ElementAt() to get to the view model, FooViewModel.
     */
    <table class="table">
        <thead>
            <tr>
                <th>@Html.DisplayNameFor(model => model.First().Key)</th>
                <th>@Html.DisplayNameFor(model => model.First().ElementAt(0).ID)</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var group in Model)
            {
                <tr>
                    <td>@group.Key</td>
                    <td>@String.Join(", ", group.Select(x => x.ID))</td>
                </tr>
            }
        </tbody>
    </table>
}
And with the fake data:
c#
public class FooViewModel
{
    [Display(Name = "Date time")]
    public DateTime DateTime { get; set; }
    [Display(Name = "Haha ID")]
    public int ID { get; set; }
}
var data = new List<FooViewModel>
{
    new FooViewModel { DateTime = new DateTime(2019, 06, 25), ID = 1 },
    new FooViewModel { DateTime = new DateTime(2019, 06, 25), ID = 2 },
    new FooViewModel { DateTime = new DateTime(2019, 06, 24), ID = 3 },
    new FooViewModel { DateTime = new DateTime(2019, 06, 23), ID = 4 }
};
It should look like:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/JtukV.png
