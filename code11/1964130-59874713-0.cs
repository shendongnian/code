    var encoding = new System.Text.UTF8Encoding();
    var htm = System.IO.File.ReadAllText(Server.MapPath("/Results/Html/") + "xyz.html", encoding);
    byte[] data = encoding.GetBytes(htm);
    Response.OutputStream.Write(data, 0, data.Length);
    Response.OutputStream.Flush();
