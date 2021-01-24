    <tbody>
    @foreach (var item in Model.FByCounty.GroupBy(x => x.CountyName))
    {
        <tr>
            <td>@item.Key</td>
            @for(int i = 1; i <= 12; i++)
            {
                <td>@item.Where(x => x.MonthName == CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(i))
                     .Select(x => x.CountyCount)
                     .SingleOrDefault()</td>
            }
        </tr>
    }
    </tbody>
