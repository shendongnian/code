@code {
    [Parameter]
    public string TbText
    {
        get => _tbText;
        set
        {
            if (_tbText == value) return;
            _tbText = value;
            TbTextChanged.InvokeAsync(value);
        }
    }
    [Parameter]
    public EventCallback<string> TbTextChanged { get; set; }
    [Parameter]
    public string Placeholder { get; set; }
    private string _tbText;
}
And the binding on my parent component looks like this:
<div class="edit-user-form">
    <AnimatedUserInput @bind-TbText="@User.ShortId" Placeholder="MHTEE Id"/>
    <AnimatedUserInput @bind-TbText="@User.FirstName" Placeholder="First name" />
    <AnimatedUserInput @bind-TbText="@User.LastName" Placeholder="Last name" />
    <AnimatedUserInput @bind-TbText="@User.UserName" Placeholder="Username" />
    <AnimatedUserInput @bind-TbText="@User.StaffType" Placeholder="Staff type" />
    <AnimatedUserInput @bind-TbText="@User.Token" Placeholder="Token" />
    <button class="btn btn-secondary" @onclick="Hide" style="{display:inline-block;}">Back</button>
    <button class="btn btn-primary" @onclick="SaveUser" style="{display:inline-block;}">Save</button>
</div>
@code {
    [Parameter] public vUser User { get; set; }
}
This way blazor can correctly bind the values together and updates them from both sides the way I would expect them to bind.
