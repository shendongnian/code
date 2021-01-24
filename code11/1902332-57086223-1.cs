    [HttpPost]
        public JsonResult Test([FromBody] ServerModel data)
        {
            try
            {
                if (string.IsNullOrEmpty(data.serverName) ||
                    string.IsNullOrEmpty(data.port))
                {
                    return Json(new { Status = "Error", Message = "Missing Data" });
                }
                else
                {
                    return Json(new { Status = "Success", Message = "Got data" });
                }
            }
            catch (Exception e)
            {
                return Json(new { Status = "Error", Message = e.Message });
            }
        }
