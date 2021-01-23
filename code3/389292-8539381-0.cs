    using (aDataContext db = new aDataContext())
                {
                    var objData = (from c in db.Companies where c.CompanyId == CompanyID select c.LogoSmall).FirstOrDefault();
                    if (objData == null)
                    {
                        context.Response.BinaryWrite(System.IO.File.ReadAllBytes(HttpContext.Current.Server.MapPath("~/Images/defaultLogo.png")));
                        
                        return;
                    }
                    using (System.IO.MemoryStream str = new System.IO.MemoryStream(objData.ToArray(), true))
                    {
                        str.Write(objData.ToArray(), 0, objData.ToArray().Length);
                        Byte[] bytes = str.ToArray();
                        context.Response.BinaryWrite(bytes);
                    }
                }
