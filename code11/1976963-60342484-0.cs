    public class CascadingModelGastos 
    {
        public string id { get; set; }
        public CascadingModelGastos()
        {
            this.Proyecto = new List<SelectListItem>();
            this.Recurso = new List<SelectListItem>();
            this.SubRecurso = new List<SelectListItem>();
        }
        public CascadingModelGastos(List<INCASICS.Models.CascadingModelGastos> lst, int rowsPerPage)
        {
            this.Proyecto = new List<SelectListItem>();
            this.Recurso = new List<SelectListItem>();
            this.SubRecurso = new List<SelectListItem>();
        }
    
        [Display(Name = "Selecciona Proyecto")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<SelectListItem> Proyecto { get; set; }
        [Display(Name = "Selecciona Recurso")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<SelectListItem> Recurso { get; set; }
        [Display(Name = "Selecciona Sub Recurso")]
        [Required(ErrorMessage = "Campo Requerido")]
        public List<SelectListItem> SubRecurso { get; set; }
    
        public int ProyectoID { get; set; }
        public int RecursoID { get; set; }
        public int SubRecursoID { get; set; }
    
        public string Nombre_Proyecto { get; set; }
    
    }
