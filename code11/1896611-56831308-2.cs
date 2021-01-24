c#
[Parameter]
protected EventCallback<int> ExternalMethod {get; set;}
and change the btnClick to
c#
public void btnClick(int param) { /* code */ }
// and then set the razor to
<TestMethodPassing ExternalMethod="@btnClick"></TestMethodPassing>
// Or do it with a lambda in the razor
<TestMethodPassing ExternalMethod="@((param) => {/* code */ })"></TestMethodPassing>
There is a GitHub issue tracking the new Event Handling and Binding [here](https://github.com/aspnet/AspNetCore/issues/6351)
