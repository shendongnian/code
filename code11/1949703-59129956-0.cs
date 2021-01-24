c#
Messages
    .GroupBy(m => new
    {
        MinId = m.SenderId <= m.RecipientId ? m.SenderId : m.RecipientId,
    	MaxId = m.SenderId > m.RecipientId ? m.SenderId : m.RecipientId
    })
    .Select(gm => gm.OrderByDescending(m => m.SentAt).FirstOrDefault());
Using `Math.Min` / `Math.Max` will only work in Entity Framework core 2, because this is the only EF version that auto-switches to client-side evaluation for any part of the query that doesn't translate into SQL. This was abandoned in EF core 3. EF core 3 only applies client-side evaluation in the final projection (`Select`), if necessary. So the `GroupBy` will fail in EF core 3, which you're going to use sooner or later.
