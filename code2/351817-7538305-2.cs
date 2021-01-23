    System.Text.StringBuilder sb = new System.Text.StringBuilder();
     sb.Append("<%@ Control Language=\"C#\" ClassName=\"m1\" %>");
     sb.Append("<script runat=\"server\">");
     sb.Append("int no=10;");
     sb.Append("public void page_load(){ for(int i=1;i<=no;i++) { Response.Write(i);} }");
     sb.Append("</script>");
     sb.Append("<h1>Hello</h1>");
    
     System.IO.File.WriteAllText(MapPath("~/pg.ascx"), sb.ToString());
     Control t = LoadControl("~/pg.ascx");
     PlaceHolder1.Controls.Add(t);
