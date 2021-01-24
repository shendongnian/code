    using Microsoft.AspNetCore.Components;
    
    namespace BlazorApp1.Components
    {
    	public partial class MyCustomComponent<T> : ComponentBase
    	{
    		[Parameter]
    		public string Label { get; set; }
    	}
    }
