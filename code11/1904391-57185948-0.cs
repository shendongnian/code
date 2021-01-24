      public class UsersViewModel
        {
            public CheckBox[] Access { get; set; }
        }
 
       /// <summary>
        /// wrapper model for display name and bool value
        /// </summary>
        public class CheckBox
        { 
            public CheckBox(string dName,bool access)
            {
                Display = dName;
                Access = access;
            }
           [Required]
           public bool Access { get; set;}
           public string Display { get; set; }
        }
