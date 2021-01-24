    <DxTextBox Text="" TextChanged=@((newValue) => OnTextChanged(newValue))></DxTextBox>
    <button type="button" class="btn btn-primary" disabled=@IsDisabled>Update Text</button>
    
    @code {
        bool IsDisabled = true;
    
        void OnTextChanged(string newValue)
        {
            if (newValue != null)
                IsDisabled = false;
    
            InvokeAsync(StateHasChanged);
        }
    }
