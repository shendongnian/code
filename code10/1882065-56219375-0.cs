    Enum.GetValues(typeof(Gender)).Cast<Gender>().Select(at =>
        new SelectListItem
        {
            Text = at.ToString(),
            Value = ((int)at).ToString()
        }
    ))
