[HttpPost]
public async Task<IActionResult> UploadFile(IFormFile file)
{
  MemoryStream ms = new MemoryStream(new byte[file.Length]);
  await file.CopyToAsync(ms);
  //here you can send these bytes as a message to Rabbit
  Model.BasicPublish(
    exchangeName,
    routingKey,
    body: ms.ToArray());
  return Ok();
}
