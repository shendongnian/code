 c#
try
{
    package.Workbook.FormulaParserManager.LoadFunctionModule(new ImporterFunctionModule());
}
catch (Exception e)
{
    for (var i=1; i < 6; i++)
    {
        _logger.LogWarning(DbLog, e, $"Could not load workbook : Loading file again (Attempt #{i})...");
        try
        {
            System.Threading.Thread.Sleep(2000);
            package.Workbook.FormulaParserManager.LoadFunctionModule(new ImporterFunctionModule());
            break;
        }
        catch (Exception ex)
        {
            if (i < 5) continue;
            _logger.LogError(DbLog, ex, "Could not load workbook after 5 attempts");
            throw;
        }
    }
}
