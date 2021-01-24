    public class Usuario{
    public int Id { get; set; }
    public string email { get; set; }
    
    [Required(ErrorMessage = "Se requiere de una denominacion")]
    [StringLength(50, MinimumLength = 2)]
    public string nombre { get; set; }
    
    [ForeignKey("alimento")]
    public int AlimentoId {get; set;}
    
    public virtual Alimento alimento { get; set; }
    }
    public class Alimento{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int codAl { get; set; }
    
    [Required(ErrorMessage = "Se requiere de una denominacion")]
    [StringLength(50, MinimumLength = 2)]
    public string Descripcion { get; set; }
    
    public string Cantidad { get; set; }
    
    [Required(ErrorMessage = "Calorias es imprescindible")]
    [DataType(DataType.Currency)]
    [Range(1, 999, ErrorMessage = "El rango debe estar entre 1 y 999")]
    public int Calorias { get; set; }
    
    public virtual ICollection<Usario> Users {get; set;}
        }
