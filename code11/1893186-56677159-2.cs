    public static decimal PriceAtVolume(IEnumerable<A> data, long requestedVolume)
    {
        return data.Aggregate(
            (Volume: 0L, Price: 0M), // Seed
            (sum, item) => // Accumulator function
            {
                if (sum.Volume == requestedVolume)
                    return sum; // Goal reached, quick return
                if (item.Available < requestedVolume - sum.Volume)
                    return // Consume all of it
                    (
                        sum.Volume + item.Available,
                        sum.Price + item.Price * item.Available
                    );
                return // Consume part of it (and we are done)
                (
                    requestedVolume,
                    sum.Price + item.Price * (requestedVolume - sum.Volume)
                );
            },
            sum => sum.Volume == 0M ? 0M : sum.Price / sum.Volume // Result selector
        );
    }
