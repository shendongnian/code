    public class FileController : Controller
    {
        [HttpPost]
        public ActionResult Upload()
        {
            string filename = Server.MapPath("/Uploads/" + Path.GetRandomFileName();
            try
            {
                using (FileStream fs = new FileStream(filename), FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        using (BinaryReader br = new BinaryReader(Request.InputStream))
                        {
                            long bCount = 0;
                            long fileSize = br.BaseStream.Length;
                            const int BLOCK_SIZE = 4096;
                            byte[] bytes = new byte[BLOCK_SIZE];
                            do
                            {
                                bytes = br.ReadBytes(BLOCK_SIZE);
                                bCount += bytes.Length;
                                bw.Write(bytes);
                            } while (bCount < fileSize);
                        }
                    }
                }
    
                return Json(new { Result = "Complete" });
            }
            catch (Exception ex)
            {
                return Json(new { Result = "Error", Message = ex.Message });
            }
        }
    }
