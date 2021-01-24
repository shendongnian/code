public async Task GeneratePDF(Guid Id) {
   var order = await _context.Orders.FirstOrDefaultAsync(order ==> order.Id == Id);
   var document = ...  //PDF generated here, takes about 10 seconds
   order.PDF = document ;
}
public async Task GenerateAllPDFs() {
   var orderIds = await _context.Orders.Select(order => order.Id).ToListAsync();
   var tasks orderIds.Select((id) => GeneratePDF(id).ContinueWith(t => Console.WriteLine(t.Exception), TaskContinuationOptions.OnlyOnFaulted));
   await Task.WhenAll(tasks);
   await _context.SaveChangesAsync();
}
