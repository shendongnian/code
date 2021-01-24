public IEnumerable<Test> GetData(){
  List<Test> result = new List<Test>();
  // Fill data from Database
  return result;
}
Or better: 
public IActionResult GetData(){
  List<Test> result = new List<Test>();
  // Fill data from Database
  return Ok(result);
}
