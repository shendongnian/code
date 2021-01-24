        <div class="form-group">
            <label asp-for="ValueType.Controller" class="m-1"></label>
            <div><span asp-validation-for="ValueType.Controller" class="text-danger"></span></div>
            <select class="custom-select" asp-for="ValueType.Controller">
                @foreach (var e in Enum.GetValues(typeof(ValueTypeModel.PageType)).Cast<int>())
                {
                    if (Enum.GetName(typeof(ValueTypeModel.PageType), e) == Model.ValueType.Controller)
                    {
                        <option value="@e.ToString()" selected>@Enum.GetName(typeof(ValueTypeModel.PageType), e)</option>
                    }
                    else
                    {
                        <option value="@e.ToString()">@Enum.GetName(typeof(ValueTypeModel.PageType), e)</option>
                    }
                }
            </select>
        </div>
