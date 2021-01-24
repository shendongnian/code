public bool CopyLatestData()
{
    using (var context = new EdDbContext())
    {
        var query = context.ELMAH_Errors.Where(x => !x.IsCopied).AsQueryable();
        //if (query.Any())
        if (query.Count() != 0) //this will check if some are left not copied
        {
            var dataToCopy = query.Take(100).ToList(); //this will only take the first 100
            var result = dataToCopy.Select(x => new parsed_errors(x)).ToList();
            
            context.parsed_errors.AddRange(result);
            dataToCopy.ForEach(x => x.IsCopied = true); //this will update the records to IsCopied = true
            context.SaveChanges();
            if (query.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
then in your timer stop timer if the bool value of the `if (Copylatestdata() == false)`
private static void timer_ElapsedActions(object sender, ElapsedEventArgs e)
{
    var stillHasRecords = CopyLatestData();
    if (!stillHasRecords)
    {
        Timer timer = (Timer)sender; //get the sender object
        timer.Stop(); // stop the sender
    }
}
