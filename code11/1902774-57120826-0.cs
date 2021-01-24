C#
public static class TaskHelpers
{
    public static async Task<(T1, T2, T3, T4)> WhenAll<T1, T2, T3, T4>(Task<T1> task1, Task<T2> task2, Task<T3> task3, Task<T4> task4)
    {
        await Task.WhenAll(task1, task2, task3, task4).ConfigureAwait(false);
        return (await task1, await task2, await task3, await task4);
    }
}
With this helper in place, your original code simplifies to:
C#
(model.Books, model.Extras, model.Invoices, model.Receipts) = await TaskHelpers.WhenAll(
    _client.GetBooks(clientId),
    _client.GetBooksExtras(clientId),
    _client.GetBooksInvoice(clientId),
    _client.GetBooksRecceipts(clientId)
);
But is it really more readable? So far, I have not been convinced enough to make this into a library.
