    var proRataDate = DateTime.UtcNow; // Or use your clock abstraction
    var proRata = new UpcomingInvoiceOptions
    {
        CustomerId = ...,
        SubscriptionId = ...,
        SubscriptionItems = ... upgraded InvoiceSubscriptionItemOptions,
        SubscriptionProrationDate = proRataDate,
        CouponId = ...
    };
    var upcomingInvoice = await _stripeInvoiceService.UpcomingAsync(proRata);
    // Note that UpcomingAsync might return the next full month's bill as well.
    var proRataCents = upcomingInvoice.Lines
        .Where(l => l.Period.Start?.Date == proRataDate.Date)
        .Sum(l => l.Amount);
