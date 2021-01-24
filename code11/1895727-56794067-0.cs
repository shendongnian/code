    public class MyModel
    {
        ...
        public int SelectedElementValue { get; set; }
    }
    Html.DropDownListFor(model => model.SelectedElementValue, Model.SelectList)
