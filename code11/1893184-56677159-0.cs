    public static double PriceAtVolume(IEnumerable<A> data, long requestedVolume)
    {
        return data.Aggregate(
            (Price: 0.0, Volume: 0L), // Seed
            (sum, item) => // Accumulator function
            {
                if (sum.Volume == requestedVolume)
                    return sum; // Goal reached, quick return
                if (item.Available < requestedVolume - sum.Volume)
                    return // Consume all of it
                    (
                        sum.Price + item.Price * item.Available,
                        sum.Volume + item.Available
                    );
                return // Consume part of it (and we are done)
                (
                    sum.Price + item.Price * (requestedVolume - sum.Volume),
                    requestedVolume
                );
            },
            sum => sum.Price / sum.Volume // Result selector
        );
    }
