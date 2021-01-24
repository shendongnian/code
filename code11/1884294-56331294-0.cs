    @*Parent.razor*@
    
    @page "/Parent"
    
    <div>
        <Child Data="@Data" ValueChanged="@ValueChanged">
        </Child>
    </div>
    
    @functions {
        List<Item> Data = new List<Item>();
    
        private void ValueChanged(Item item)
        {        
        }
    }
        @*Child.razor*@
    
    @typeparam TData
    
    <div>
        @foreach (var item in Data)
        {
            <button onclick="@(() => ValueChanged.InvokeAsync(item))"></button>
        }
    </div>
    
    @functions {
        [Parameter]
        public IEnumerable<TData> Data { get; set; }
    
        [Parameter]
        protected EventCallback<TData> ValueChanged { get; set; }
    }
  
      // Item.cs
    public class Item
    {
         public Item()
         {
    
         }
    }
   
