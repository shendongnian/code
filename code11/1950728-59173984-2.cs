    // at this line you start enumerating the your collection
    foreach (object item in SelectedHobbies.Items)
    {
        // **** and here probably you are restarting the enumeration?
        // as pointed out the above statement is incorrect there is not enough
        // information point to the step that is changing the collection
        // backing the enumeration in the original post
        string hobby = SelectedHobbies.Items.ToString();
    ...
