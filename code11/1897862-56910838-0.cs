C#
public class MyClass
{
  const string SQL = "SELECT Value FROM Table1 WHERE UniqueCode = @I";
  private async Task<int> MyMethodCore(int i, bool sync)
  {
    var r1 = i + 4;
    var r2 = sync ? MockDbAccess.GetDbResult(r1, SQL) : await MockDbAccess.GetDbResultAsync(r1, SQL);
    var r3 = r1 + r2 * 7;
    return r3;
  }
  public int MyMethodSync(int i) => MyMethodCore(i, sync: true).GetAwaiter().GetResult();
  public Task<int> MyMethodAsync(int i) => MyMethodCore(i, sync: false);
}
  [1]: https://msdn.microsoft.com/en-us/magazine/mt238404.aspx
