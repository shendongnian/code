    async Task OnClickInternal()
        {
           // verify that the delegate associated with this event dispatcher is non-null
            if (OnClick.HasDelegate)
            {
                await OnClick.InvokeAsync(Item);
            }
        }
