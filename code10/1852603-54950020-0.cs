    public class EstablishmentOptionView
    {
        public int EstablishmentId { get; set;}
        public string Description { get; set;}
    }
    public List<EstablishmentOptionView> getEstablishments()
    {
                var db = new mydbContext();
                result=db.TblEstablishment.Select(x => new EstablishmentOptionView {EstablishmentId = x.Id, Description = x.Description }).ToList();
    
                db.Dispose();
                return result;
     }
    //somewhere else 
    SomeDropDownList.DataValueField = "EstablishmentId";
    SomeDropDownList.DataTextField = "Description";
    SomeDropDownList.DataSource = getEstablishments();
    SomeDropDownList.DataBind();
