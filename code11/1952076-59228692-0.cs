lang-c#
public class AuditMailModel
{
    public int AuditId { get; set; }
    public int RolId { get; set; }
    public string Valores { get; set; }
}
Then in your controller:
lang-c#
public async Task<IActionResult> Save([FromBody] AuditMailModel model)
{
    return Json(await _repository.Save(model.AuditId, model.RolId, model.Valores));
}
