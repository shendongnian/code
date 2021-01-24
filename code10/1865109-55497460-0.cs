    if (txt.SelectionStart == 0 || txt.SelectionStart == 2 || txt.SelectionStart == 4)
    {
        txt.InputType = InputTypes.ClassText | InputTypes.TextFlagCapCharacters;
        txt.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(maxLength) });
    }
    else if (txt.SelectionStart == 1 || txt.SelectionStart == 3 || txt.SelectionStart == 5)
    {
        txt.InputType = InputTypes.ClassNumber;
        txt.SetFilters(new IInputFilter[] { new InputFilterLengthFilter(maxLength) });
    }
