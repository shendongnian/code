public DateTime DeathDate { get; set; }
to
public DateTime? DeathDate { get; set; } //Nullable
And check if its got value by using `DateTime?.HasValue` property.
if (!DeathDateDatePicker.SelectedDate.HasValue)
{
    //  Your code here
}
