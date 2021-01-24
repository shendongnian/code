    @using System;
    
    <HeadingComponent HeadingText="@HeadingText" />
    
    <ListItemsComponent Items="@ListItems" />
    
    <SubmitButtonComponent ButtonText="add item" OnClick="@AddItem" />
    
    @code {
        [Parameter]
        public string HeadingText { get; set; } = "MyList";
    
        [Parameter]
        public List<string> ListItems { get; set; } = new List<string> { "One", "Two" };
    
        // Note: this property has been removed
        // public string Item { get; set; }
    
        private void AddItem(string item)
        {
            ListItems.Add(item);
        }
    }
