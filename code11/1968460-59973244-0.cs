    public class MenuPermission
    {
        [Key]
        public string Id { get; set; }
        // Other properties go here
        public string RoleId { get; set; }
    	[ForeignKey("RoleId ")] 
        public virtual RoleDTO Role_RoleId { get; set; }
    	
        public string UserId { get; set; }
        public virtual ExpandedUserDTO User_UserId { get; set; } // this seems to be configuration issue. Database says UserId is issue but ExpandedUserDTO says UserName is key.
        // Other properties go here
    } 
