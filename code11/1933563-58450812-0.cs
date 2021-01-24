 lang-cs
public class AEntity
{
  public Guid Id { get; set; }
  public string Name { get; set; }
  public ISet<AEntity> A { get; set; } = null;
}
<br />
**Single-Join-Request:**
----
 lang-cs
public async Task<AEntity> GetById(Guid id)
{
  using (var connection = Connection)
  {
    var as= new Dictionary<Guid, BEntity>();
    return (await connection.QueryAsync<AEntity, BEntity, AEntity>(
      sql: $"SELECT a.*, b.* FROM ab INNER JOIN a ON a.id = ab.a_id INNER JOIN b ON b.id = ab.b_id WHERE a.id=@id",
      map: (a, b) => {
        if (!as.TryGetValue(a.Id, out var entity))
        {
          entity = a;
          entity.B= new HashSet<b>();
          as.Add(a.Id, entity);
        }
        entity.B.Add(b);
        return entity;
      },
      param: new {
        id
      }
    )).FirstOrDefault();
  }
}
<br />
**All-Join-Request:**
----
 lang-cs
public async Task<IEnumerable<AEntity>> GetById(Guid id)
{
  using (var connection = Connection)
  {
    var as= new Dictionary<Guid, BEntity>();
    return (await connection.QueryAsync<AEntity, BEntity, AEntity>(
      sql: $"SELECT a.*, b.* FROM ab INNER JOIN a ON a.id = ab.a_id INNER JOIN b ON b.id = ab.b_id",
      map: (a, b) => {
        if (!as.TryGetValue(a.Id, out var entity))
        {
          entity = a;
          entity.B= new HashSet<b>();
          as.Add(a.Id, entity);
        }
        entity.B.Add(b);
        return entity;
      },
      param: new {
        id
      }
    )).Distinct();
  }
}
<br />
**(All-Join-Request) returned tupel / object:**
----
 lang-json
[
  {
    "id": "F3613B62-EEB5-4B27-9A20-4038F60B25BD",
    "name": "name-01-of-a",
    "b": [
      {
        "id": "19C592B1-4D4C-4660-9D1D-C5C4AA1F296C",
        "name": "name-01-of-b"
      },
      {
        "id": "C71E6490-2410-4FA3-A4D0-F24B8207B67A",
        "name": "name-02-of-b"
      }
    ]
  },
  {
    "id": "6A68ED79-5605-43B4-9F70-675CAF3C5C65",
    "name": "name-02-of-a",
    "b": [
      {
        "id": "D763F490-A6B6-4FCB-A3BA-755A44E16D6F",
        "name": "name-03-of-b"
      },
      {
        "id": "19C592B1-4D4C-4660-9D1D-C5C4AA1F296C",
        "name": "name-01-of-b"
      }
    ]
  },
  {
    "id": "76CB90D6-93BE-452E-8A72-F525180B77E8",
    "name": "name-03-of-a",
    "b": [
      {
        "id": "D763F490-A6B6-4FCB-A3BA-755A44E16D6F",
        "name": "name-03-of-b"
      },
      {
        "id": "19C592B1-4D4C-4660-9D1D-C5C4AA1F296C",
        "name": "name-01-of-b"
      },
      {
        "id": "C71E6490-2410-4FA3-A4D0-F24B8207B67A",
        "name": "name-02-of-b"
      }
    ]
  }
]
<br />
Now the stuff works fine. I just used a simple **helper-dictionary** to buffer the separate Bs into the right As. And I changed the **IEnumerable** to a ISet (HashSet), because the .Add()-Method. :)
Hope somebody can use my solution.
  [1]: https://i.stack.imgur.com/tH4lM.png
