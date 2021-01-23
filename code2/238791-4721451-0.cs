    private void DisplayBuiltinDocumentProperties()
{
    Office.DocumentProperties documentProperties1 =
        (Office.DocumentProperties)this.BuiltinDocumentProperties;
    if (documentProperties1 != null)
    {
        for (int i = 1; i <= documentProperties1.Count; i++)
        {
            Office.DocumentProperty dp = documentProperties1[i];
            Globals.Sheet1.Range["A" + i.ToString(), missing].Value2 =
                dp.Name;
        }
    }
