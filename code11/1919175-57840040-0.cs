    @using Microsoft.AspNetCore.Components.Rendering
    @*tested with preview 9*@
    @{ GreetPerson(__builder, "John"); }
    
    @code {
    
        void GreetPerson(RenderTreeBuilder __builder, string name)
        {            
            <p>Hello, <em>@name!</em></p>
        }
    }
