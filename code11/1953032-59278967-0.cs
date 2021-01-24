    [Route("{rdmId}/files/{fileName}")]
    public class RDMFilesController : Controller
    {
        /// <summary>
        /// Creates a new file for the given RDM. If the file already exists an error is returned.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> PUT([BindRequired, FromRoute]string rdmId, [BindRequired, FromRoute]string fileName, [FromForm]IFormFile file)
        {
             // DO STUFF
        }
    }
