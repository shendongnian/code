    public partial class SecurityUser
        {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public SecurityUser()
            {
                this.SW_Mobile_Pick_Assignment = new HashSet<SW_Mobile_Pick_Assignment>();
                this.SW_Mobile_Session = new HashSet<SW_Mobile_Session>();
               
            }
        
            public int SecurityUserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Login { get; set; }
            public string Passwrd { get; set; }
            public string Email { get; set; }
            public bool Enable { get; set; }
            public string FileMakerId { get; set; }
            public string Phone { get; set; }
            public string Fax { get; set; }
            public Nullable<bool> IsAccountManager { get; set; }
            public Nullable<bool> IsHandHeldAccount { get; set; }
            public Nullable<int> HandheldPin { get; set; }
            public string Last5SSN { get; set; }
        
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<SW_Mobile_Session> SW_Mobile_Session { get; set; }
    }
