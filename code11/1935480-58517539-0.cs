<div class="panel panel-default">
    <div class="panel-heading">@Title</div>
    <div class="panel-body">@ChildContent</div>
    <button class="btn btn-primary" @onclick="OnClick">
        Trigger a Parent component method
    </button>
</div>
@code {
    public string Title { get; set; }
    public RenderFragment ChildContent { get; set; }
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}
Without the `[Parameter]` attribute, those are just public properties that can't be set from other pages. The following line would be invalid :
<ChildComponent Title="Panel Title from Parent" />
While this :
<div class="panel panel-default">
    <div class="panel-heading">@Title</div>
    <div class="panel-body">@ChildContent</div>
    <button class="btn btn-primary" @onclick="OnClick">
        Trigger a Parent component method
    </button>
</div>
@code {
    [Parameter]
    public string Title { get; set; }
    [Parameter]
    public RenderFragment ChildContent { get; set; }
    [Parameter]
    public EventCallback<MouseEventArgs> OnClick { get; set; }
}
Allows us to set the parameters whenever we use that component :
<ChildComponent Title="Panel Title from Parent"
                OnClick="@ShowMessage">
    Content of the child component is supplied
    by the parent component.
</ChildComponent>
