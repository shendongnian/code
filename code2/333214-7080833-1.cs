    [System.Web.Services.WebMethod]
    public static string ebulten_Add(string ebEmail)
    {
        if (ebEmail == "Email")
        {
            return "{ \"response\": \"*Bilgilerinizi Girmediniz\"}";
        }
        else
        {
            List<ListItem> ebList = new List<ListItem>();           
            ebList.Add(new ListItem("@Eb_email", ebEmail));
            BL.Atom.GetByVoid("spEbulten_Add", ebList);
            return "{ \"response\": \"*E-Bülten kaydiniz basariyla tamamlanmistir\"}";            
        }
    }
