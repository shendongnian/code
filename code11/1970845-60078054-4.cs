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
   ...
   // act / assert
   var result = await _awsDynamoDbManager.WriteData(item, _bankStatementTable);
   Assert.IsFalse(result);
}
Since there is no awaitable code inside `WriteData` method, you can make it synchronous one and use `Task.FromResult` as return result or make it even simpler and remove using of `Task<bool>`
cs
public bool WriteData(Document data, string tableName)
{
   try
   {
      var table = Table.LoadTable(_dynamoDbClient, tableName);
      table.PutItem(data);
      return true;
   }
   catch (Exception e)
   {
     _logger.Info("Failed Writing Record");
     _logger.Info("Error: " + e.Message);
     return false; //or throw;
   }
}
And the synchronous test code
cs
Assert.Throws<System.Exception>(() => _awsDynamoDbManager.WriteData(item, _bankStatementTable));
or
cs
public void TestToSeeIfWeGetAnExceptionWhenProvidingBadDataToTheDatabase()
{
   // arrange
   ...
   // act / assert
   var result = _awsDynamoDbManager.WriteData(item, _bankStatementTable);
   Assert.IsFalse(result);
}
