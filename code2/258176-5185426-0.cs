    public class stuff {
    string pagetitle;
    string contentID;
    string nodeID; 
    }
    [System.Web.Services.WebMethod]
    public static stuff EditPage(string nodeID) {
    ... get the stuff
       stuff returnme = new stuff();
       returnme.pagetitle = ...
       returnme.contentid = ...
       return returnme;
    }
