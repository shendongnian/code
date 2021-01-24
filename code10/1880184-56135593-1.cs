public class CosmosGuid : IEquatable<Guid>
{
  ....
  public bool Equals(Guid other) {
    return this.Guid == other;
  }
}
.Where(x => cosmosGuid.Equals(x.Id))
