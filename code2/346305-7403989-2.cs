    <table id="criteriaTable">
    @foreach (var field in form.Fields)
    {
        <tr id="criteriaTableRow">
        @if (field.IsVisible)
        { 
        <td id="criteriaTableLabelCol"> 
           @Html.DevExpress().Label(s => s.Text = field.Caption).GetHtml()
        </td>
        <td id="criteriaTableEditCol">
            @if (field.Type == typeof(bool))
            {
               @Html.CheckBox(s =>
          {
              s.Checked = field.IsBoolSet;
              s.Name = field.Name;
              s.ClientEnabled = !field.IsReadonly;
          }).GetHtml()
            }
            else if (field.Type == typeof(DateTime))
            {
                Html.DevExpress().DateEdit(s =>
                {
                    s.Name = field.Name;
                    s.ClientEnabled = !field.IsReadonly;
                    if (!string.IsNullOrEmpty(field.Value))
                    {
                        DateTime dateValue;
                        if (DateTime.TryParse(field.Value, out dateValue))
                            s.Date = dateValue;
                    }
                }).GetHtml();
            }
            else if (field.ListValues.Count > 0)
            {
                <input type="hidden" id="@("initiallySelected" + field.Name)" value="@field.Value" />
                Html.DevExpress().ListBox(s =>
                {
                    s.Name = field.Name;
                    s.ClientVisible = field.IsVisible;
                    s.ClientEnabled = !field.IsReadonly;
                    s.Properties.SelectionMode = DevExpress.Web.ASPxEditors.ListEditSelectionMode.CheckColumn;
                    s.Properties.TextField = "Name";
                    s.Properties.ValueField = "Value";
                    s.Properties.ValueType = typeof(string);
                    
                    //s.Properties.EnableClientSideAPI = true;
                    foreach (var item in field.ListValues)
                    {
                        s.Properties.Items.Add(item.Name, item.Value);
                    }
                    
                    //s.Properties.ClientSideEvents.SelectedIndexChanged = "MultiSelectListChanged";
                    s.Properties.ClientSideEvents.Init = "MultiSelectListInit";
                }).GetHtml();
            }
            else
            {
                //Html.TextBox(field.Name, field.Value)
                Html.DevExpress().TextBox(s =>
                {
                    s.Name = field.Name; s.Text = field.Value;
                }).GetHtml();
            }
            @Html.ValidationMessage(field.Name)
            <input type="hidden" name="@("oldvalue_" + field.Name)" value="@field.Value" />
            <input type="hidden" name="@("olduse_" + field.Name)" value="@(field.IncludeInSearch ? "C" : "U")" />
        </td>
        <td id="criteriaTableIncludeCol"> 
            @Html.DevExpress().CheckBox(s =>
       {
           s.Checked = field.IncludeInSearch;
           s.Name = "use_" + field.Name;
           s.ClientEnabled = (!field.IsMandatory);
       }).GetHtml()
        </td>
        }
        </tr>
    }
        </table>
