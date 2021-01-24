 c#
var Book2 = default(pBook);
// the rest unchanged
which fools definite assignment by explicitly setting everything to zero. However! IMO the real fix here is "no mutable structs". Mutable structs **will hurt you**. I would suggest:
 c#
var Book2 = new pBook("a", "b", 201, 0);
with (note: this uses recent C# syntax; for older C# compilers, you may need some tweaks):
 c#
public readonly struct Book
{
    public Book(string request, string response, int status, int testId)
    {
        Request = request;
        Response = response;
        Status = status;
        TestId = testId;
    }
    public string Request { get; }
    public string Response { get; }
    public int Status { get; }
    public int TestId { get; }
};
