public async Task GenerateAllPDFs() {
   var orderIds = await _context.Orders.Select(order => order.Id).ToListAsync();
   var tasks orderIds.Select((id) => GeneratePDF(id).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted));
   await Task.WhenAll(tasks);
}
