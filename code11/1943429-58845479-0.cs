cs
@foreach(var month in _months)
{
    <ul>
        <li><label for="@month.MonthId">@month.MonthName</label></li>
        <li><InputCheckbox id="@month.MonthId" @bind-Value="@month.IsMonthChecked" /></li>
    </ul>
}
@code {
    private IEnumerable<Month> _months;
    protected override void OnInitialized()
    {
        _months = new List<Month>
        {
            new Month{ MonthId = 0, MonthName = "All Months", IsMonthChecked = false },
            new Month{ MonthId = 1, MonthName = "Jan", IsMonthChecked = false },
            new Month{ MonthId = 2, MonthName = "Feb", IsMonthChecked = false },
            new Month{ MonthId = 3, MonthName = "Mar", IsMonthChecked = false },
            new Month{ MonthId = 4, MonthName = "Apr", IsMonthChecked = false },
            new Month{ MonthId = 5, MonthName = "May", IsMonthChecked = false },
            new Month{ MonthId = 6, MonthName = "Jun", IsMonthChecked = false },
            new Month{ MonthId = 7, MonthName = "Jul", IsMonthChecked = false },
            new Month{ MonthId = 8, MonthName = "Aug", IsMonthChecked = false },
            new Month{ MonthId = 9, MonthName = "Sep", IsMonthChecked = false },
            new Month{ MonthId = 10, MonthName = "Oct", IsMonthChecked = false },
            new Month{ MonthId = 11, MonthName = "Nov", IsMonthChecked = false },
            new Month{ MonthId = 12, MonthName = "Dec", IsMonthChecked = false }
        };
        base.OnInitialized();
    }
}
