cs
catch (Exception e)
{
     _logger.Info("Failed Writing Record");
     _logger.Info("Error: " + e.Message);
     throw;
}
...
Assert.ThrowsAsync<System.Exception>(async () => await _awsDynamoDbManager.WriteData(item, _bankStatementTable));
Or check that `WriteData` returns `false` by making test as `async` as well and call `Assert.IsFalse`
cs
public async Task TestToSeeIfWeGetAnExceptionWhenProvidingBadDataToTheDatabase()
{
   // arrange
   var item = new Document
   {
      ["Id"] = "1001",
      ["TransactionID"] = 111111,
      ["StatementType"] = "TestBank"
   };
   _bankStatementTable = "does-not-exist";
   // act / assert
   var result = await _awsDynamoDbManager.WriteData(item, _bankStatementTable);
   Assert.IsFalse(result);
}
