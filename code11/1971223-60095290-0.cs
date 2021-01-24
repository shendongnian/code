            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader($"content-disposition", "attachment;filename=" + "{reportFileName}" + ".xlsx");
            using (System.IO.MemoryStream MyMemoryStream = new MemoryStream())
            {
                MyMemoryStream.Write(result, 0 , result.Length);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
                return File(MyMemoryStream.ToArray(), "application/octet-stream");
            }
