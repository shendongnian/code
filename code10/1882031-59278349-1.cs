    using Microsoft.AspNetCore.Components;
    
    namespace FirstBlazorWasm.Pages //my test namespace
    {
        public partial class Counter //<--- note the partial class definition 
        {
    
            private int currentCount;
    
            private void IncrementCount()
            {
                currentCount++;
            }
        }
    }
