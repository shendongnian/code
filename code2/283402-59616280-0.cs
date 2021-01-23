    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Net.Http.Headers;
    [Route("api/[controller]")]
    [ApiController]
    public class FileHandlingController : ControllerBase
    {
        [HttpGet]
        public FileContentResult Download(int attachmentId)
        {
            TaskAttachment taskFile = null;
            if (attachmentId > 0)
            {
                // taskFile = <your code to get the file>
                // which assumes it's an object with relevant properties as required below
                if (taskFile != null)
                {
                    var cd = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                    {
                        FileNameStar = taskFile.Filename
                    };
                    Response.Headers.Add(HeaderNames.ContentDisposition, cd.ToString());
                }
            }
            return new FileContentResult(taskFile?.FileData, taskFile?.FileContentType);
        }
    }
