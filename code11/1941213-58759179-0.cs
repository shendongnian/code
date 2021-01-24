C#
// GET: api/MeshDatas
        [HttpGet]
        public async Task<ActionResult<MeshDataListObject>> GetMeshData() //Returnable type changed here
        {
            MeshDataListObject returnable = new MeshDataListObject();
            returnable.meshDatas = await _context.MeshData.ToListAsync();
            return returnable;
        }
C#
public class MeshDataListObject {
    public IEnumerable<MeshData> meshDatas; //Something to hold the result you want to return. 
//This will be serialized to something like {"meshDatas":[]}
}
