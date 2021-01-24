    public class Request
    {
        ...
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    public Request GetChangeRequest()
    {
        using (var context = new Data.Core.Context())
        {
            while (true)
            {
                try
                {
                    var request = context.Requests
                        .Where(r => r.IsAvaible)
                        .FirstOrDefault();
                    request.IsAvaible = false;
                    context.SaveChanges();
                    return request;
                }
                catch (DbUpdateConcurrencyException)
                {
                }
            }
        }
    }
