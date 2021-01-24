 c#
try
{
    // ... what you had before
}
catch (Exception ex)
{
    while (ex != null)
    {
        Debug.WriteLine(ex.Message);
        ex = ex.InnerException;
    }
    throw;
}
This should tell you what *exactly* it finds objectionable about the model, in the debug output (or just put a break-point on the `Debug.WriteLine` line, and read all of the messages in the debugger).
