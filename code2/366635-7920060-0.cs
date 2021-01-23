    [WebMethod(EnableSession = true)]
    public string ReadUserAdditional()
    {
        return GetUserInfo<UserAdditionalDto>();
    }
    
    private string GetUserInfo<TDto>(FieldInfo[] infos) 
    {
        EUser user = (EUser)Session["user"];
    
        var dto = Mapper.Map<TDto>(user); // Mapper is Automapper entry class.
    
        return new JavaScriptSerializer().Serialize(dto );
    }
    
    public class UserAdditionalDto
    {
        public string Image { get; set; }
        public string Biography { get; set;}
    }
