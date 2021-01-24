<p>@Message</p>
@code {
    [Parameter]
    public string Message {get;set;}
}
and in your `Test.razor`
@page "/Test"
@if (option == 1)
{
    <drawSomething Message="Something" />
}
else
{
    <drawSomething Message="Something else" />
}
@code {
    int option;
}
Here I assuming that you have something more complex, then just plain <p>.
**Version 2**
If you really want easy way, then just 
@page "/Test"
@if (option == 1)
{
    <p>Something</p>
}
else
{
    <p>Something else</p>
}
@code {
    int option;
}
**Version 3**
Based on suggestion from Isaac
@page "/Test"
@if (option == 1)
{
    <drawSomething Message="Something" />
}
else
{
    <drawSomething Message="Something else" />
}
@code {
    int option;
    RenderFragment drawSomething(string message)
    {
        return @<p>@message</p>;
    }
}
