lang-cs
public class DAL.QuestionOption
{
    public DAL.Option Option { get; set; }
    public boolean isDeleted { get; set; }
}
public class DAL.Option
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Value { get; set; }
}
If so, I would just change the `MapOption` to take in the `DAL.QuestionOption` instead of `DAL.Option`:
lang-cs
private DTO.Option MapOption(DAL.QuestionOption o)
{
    return new DTO.Option()
    {
        ID = o.Option.ID,
        Text = o.Option.Text,
        Value = o.Option.Value,
        Deleted = o.isDeleted
    };
}
