    public HttpPostedFileBase Indir(string documentId)
        {
           using (ISession session=FluentNHibernateHelper.OpenSession())
            {
                var doc = new Document();
                var docDet = new DocumentDetail();
                doc = session.Query<Document>().FirstOrDefault(x => x.Id == Convert.ToInt32(documentId));
                docDet = session.Query<DocumentDetail>().FirstOrDefault(x=>x.DocumentId==doc.Id);
                var test = new MemoryPostedFile(docDet.File,doc.DocumentName,doc.DocumentExtention);
                Response.Clear();
                Response.ContentType = doc.DocumentExtention;//"application/octet-stream";
                Response.AddHeader("Content-Disposition","attachment; filename="+test.FileName+";");
                Response.BinaryWrite(docDet.File);
                Server.MapPath("~/"+test.FileName);
                Response.End();
                return test;
            }
        }
