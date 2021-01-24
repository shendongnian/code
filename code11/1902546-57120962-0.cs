C#
public class BaseForm {
    public ShowPanel() {
        ...
    }
    public HidePanel() {
        ...
    }
}
public class FormImplementation : BaseForm {
    private async void OnEventAsync(object sender, EventArgs e) {
        ShowPanel();
        try { ... }
        finally { HidePanel(); }
    }
}
You can minimize the code changes by using a disposable, e.g., (using [my Nito.Disposables library][2]) with a C# 8 [using declaration][3]:
C#
public class BaseForm {
    public IDisposable ShowPanel() {
        ...
        return new AnonymousDisposable(HidePanel);
    }
    private void HidePanel() {
        ...
    }
}
public class FormImplementation : BaseForm {
    private async void OnEventAsync(object sender, EventArgs e) {
        using var _ = ShowPanel();
        ...
    }
}
There are other alternatives, such as changing the return type of `OnEventAsync` to be `Task`, but that would require more code changes I think than just doing the above.
  [1]: https://blog.stephencleary.com/2013/11/there-is-no-thread.html
  [2]: https://www.nuget.org/packages/Nito.Disposables
  [3]: https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-8.0/using#using-declaration
