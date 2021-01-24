    <EditableClass Item="@item"><button class="btn btn-danger" @onclick="@(() => Delete(item))">DeleteMe</button></EditableClass>
    public void Delete(TItem itemToDelete)
        {
            DataInstance.Delete(itemToDelete);
          //  StateHasChanged();
           // Console.WriteLine("Here");
        }
