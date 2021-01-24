        public class UserVM
        {
            public UserVM()
            {
                IsActivo = true;
            }
            public int Id { get; set; }
            [Required]
            [Display(Prompt = "Username")]
            public string Username { get; set; }
            [Display(Name = "Último Acesso")]
            public DateTime? DataSessao { get; set; }
            [Display(Name = "Activo")]
            public bool IsActivo { get; set; }
            public ICollection<int> RoleIds { get; set; }
        }
