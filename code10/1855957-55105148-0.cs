    [DataType(DataType.DateTime)]
    [DisplayFormat(DataFormatString = "{0:dddd, dd MMMM HH:mm:ss}")]
    public DateTime LogDate { get; set; }
    ...
    @Html.DisplayFor(m => m[i].LogDate)
