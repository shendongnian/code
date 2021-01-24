c#
 <Label For="@(() => Model.Name))" />
c#
@using System.Linq
@using System.Reflection
@using System.ComponentModel
@using System.Linq.Expressions;
<label>@label</label>
@code {
   
    [Parameter] public Expression<Func<string>> For { get; set; }
    private string label => GetDisplayName();
    private string GetDisplayName()
    {
        var expression = (MemberExpression)For.Body;
        var value = expression.Member.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute;
        return value?.DisplayName ?? expression.Member.Name ?? "";
    }
}
