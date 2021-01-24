        <div style="border:solid 1px red">
         <select id="Item" class="form-control-sm" @bind="@Item">
            @foreach (var l in list)
            {
                @if (Item != null && String.Equals(l, Item, 
                 StringComparison.OrdinalIgnoreCase))
                {
                    <option selected value="@l">@l</option>
                }
                else
                {
                    <option value="@l">@l</option>
                }
            }
        </select>
     </div>
     <p>@Item</p>
     @code {
      public IEnumerable<string> list = new List<string>()
     {
        "Item 1",
        "Item 2",
        "Item 3",
        "Item 4",
        "Item 5"
     };
     private string item { get; set; } 
     [Parameter]
     public string Item
     {
        get { return item; }
        set
        {
            if (item != value)
            {
                item = value;
                if (ItemChanged.HasDelegate)
                {
                    ItemChanged.InvokeAsync(value);
                }
            }
        }
      }
     [Parameter]
     public EventCallback<string> ItemChanged { get; set; }
     }
