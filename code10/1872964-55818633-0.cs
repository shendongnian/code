    List<string> listStatus = new List<string>();
    string body = "";
            for (int i = 0; i < listStatus.Count; i++)
            {
                string var = listStatus[i].ToString();
                body = body + var + "</br>";
            }
            Response.Write(body + "</br>");
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "openModal('" + body + "');", true);
            ClientScript.RegisterStartupScript(this.GetType(), "Show", "showModal()", true);
