public async Task GeneratePDF(Order order) {
   var document = ...  //PDF generated here, takes about 10 seconds
   order.PDF = document ;
}
public async Task GenerateAllPDFs() {
   var orderIds = await _context.Orders.ToListAsync();
   var tasks orderIds.Select((order) => GeneratePDF(order).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted));
   await Task.WhenAll(tasks);
   await _context.SaveChangesAsync();
}
