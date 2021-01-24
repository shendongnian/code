<div class="alert alert-primary" role="alert">
    @ChildContent
</div>
@code {
    [Parameter] public RenderFragment ChildContent { get; set; }
}
Step 2, create an AlertGroup component:
This is a component that can handle an IEnumerable of T alerts.
We'll use TItem to specify that the AlertGroup is generic. It can handle any object we throw at it. Next, we iterate over the `IReadOnlyList<TItem> Items` and render each user defined template inside of an `AlertMessage`.
@typeparam TItem
@foreach (var item in Items)
{
    <AlertMessage>
        @AlertTemplate(item)
    </AlertMessage>
}
@code {
    [Parameter]
    public RenderFragment<TItem> AlertTemplate { get; set; }
    [Parameter]
    public IReadOnlyList<TItem> Items { get; set; }
}
Step 3, put it to use:
Here's the obligatory Counter component. We'll hijack its behavior to render an alert on each count. We'll also capture the total count in a separate Razor output by simply calling `@alerts.Count()`. To the OP, we don't need to track the count internally, since we're feeding TItem from the parent.
Since I'm using a type of `int` in the example, I've defined the built in `Context` parameter as `Value`. If this were an object, the type would likely be inferred and we could use dot notation, ex: `context.Prop`.
@page "/counter"
<h1>Counter</h1>
<p>Current count: @currentCount</p>
<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
<AlertMessageGroup Items="alerts" Context="Value">
    <AlertTemplate>
        <span>My value is @Value</span>
    </AlertTemplate>
</AlertMessageGroup>
<p>@alerts.Count()</p>
@code {
    List<int> alerts = new List<int>();
    private int currentCount = 0;
    private void IncrementCount()
    {
        currentCount++;
        alerts.Add(currentCount);
    }
}
