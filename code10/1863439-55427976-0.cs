    <select onchange="@ComboSelectionChanged">
            <option value="0" selected>
                @list[0]
            </option>
            @for (int i = 1; i < list.Count; i++)
            {
                <option value="@i">
                    @list[i]
                </option>
            }
        </select>    
    public void ComboSelectionChanged(UIChangeEventArgs e)
        {
            if (int.TryParse(e.Value.ToString(), out int index))
            {
                SelectedStyleIndex = index
                 //now you know which one is selected
            }
        }    
