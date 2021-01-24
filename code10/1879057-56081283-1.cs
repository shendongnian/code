public class FooModel
{
    public Guid Id { get; set; }
    public Status Situacao { get; set; }
}
should be
public class FooModel
{
    public Guid Id { get; set; }
    public Status? Situacao { get; set; }
}
Also, I would highly recommend setting a safe default value for your enum, example:
public enum Status
{
    None,
    Pendente,
    EmProcessamento,
    Processada
}
