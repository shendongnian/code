    @using System.Reflection
    @using System.Linq.Expressions;
    @using System.ComponentModel.DataAnnotations;
    @typeparam T
    @if (ChildContent == null)
    {
        <label>@label</label>
    }
    else
    {
        <label>
            @label
            @ChildContent
        </label>
    }
    @code {
        [Parameter] public Expression<Func<T>> For { get; set; }
        [Parameter] public RenderFragment ChildContent { get; set; }
    
        private string label => GetDisplayName();
    
        private string GetDisplayName()
        {
            var expression = (MemberExpression)For.Body;
            var value = expression.Member.GetCustomAttribute(typeof(DisplayAttribute)) as DisplayAttribute;
            return value?.Name ?? expression.Member.Name ?? "";
        }
    }
