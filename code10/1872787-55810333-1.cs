public class Contents
{
	public string RecipientType;
	public string Email;
	public string SubTeam;
}
Declare a global variable in code behind 
List<Contents> Data;
Put the following in pageload.
 if (!Page.IsPostBack)
    {
         Data = new List<Contents>();
         Session["Data"] = Data;
    }
    else
         Data = (List<Contents>) Session["Data"];
In your Add Button event do this.
protected void AddRecipient_Click(object sender, EventArgs e)
{
		var newItem = new Contents
                      {
                         RecipientType = Request.Form["recname"],
                         Email = Request.Form["emailname"],
                         SubTeam = Request.Form["subteamname"]
                      };
		Data.Add(newItem);
		Session["Data"] = Data;
}
Advantage of doing this is, you can actually bind "Data" to your gridview. And then you can implement update, delete very easily.
