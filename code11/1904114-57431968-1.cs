            public HttpResponseMessage XlsGLARM(string CfCommit, string Periodo)
        {
            // here I load an Excel Template and build the workbook
            // and fill it. But iit's not realted to your question.
                using (MemoryStream tmpStream = new MemoryStream())
                {
                    Response.Clear();
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                    Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                    workbook.Write(tmpStream);
                    Response.BinaryWrite(tmpStream.ToArray());
                    Response.End();
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
