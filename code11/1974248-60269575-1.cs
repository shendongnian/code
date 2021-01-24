    <!-- Select Component -->
    <div class="form-group">
        @if (message != null)
        {
            <p class="text-warning">@message</p>
        }
        <label for="Item" class="form-check-label">Item</label>
        @if (list == null)
        {
            <input id="Item" class="form-control" @bind="@Item" />
        }
        else
        {
            <select id="Item" class="form-control" @bind="@Item">
                @foreach (var l in list)
                {
                    <option value="@l">@l</option>
                }
            </select>
        }
    </div>
    @code {
        private string message;
    
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
                if (item != value)  // skip if it's the same string
                {
                    // validate the new item value against my list
                    foreach (var l in list)
                    {
                        if (value != null && String.Equals(l, value, StringComparison.OrdinalIgnoreCase))
                        {
                            item = l;   // match exact case to my list so "selected" option works properly
                            message = null;
                        }
                    }
    
                    // if there's no match, clear the item
                    if (!String.Equals(item, value, StringComparison.OrdinalIgnoreCase))
                    {
                        item = null;
                        message = "Invalid Item";
                    }
    
                    // make sure there is a parent
                    if (ItemChanged.HasDelegate)
                    {
                        // this is the magic that updates the parent
                        ItemChanged.InvokeAsync(item);
                    }
                }
            }
        }
    
        [Parameter]
        public EventCallback<string> ItemChanged { get; set; }
    }
