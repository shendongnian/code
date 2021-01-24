    public class Categoria 
    {
        [Key]
        public int id { get; set; }
        public string descricao { get; set; }
        public string observacao { get; set; }
        public int status { get; set; }
        public virtual ICollection<Produto> produtos { get; set; }
    }
    public class Produto 
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("categoria")]
        public int categoriaId {get; set;}
        public string descricao { get; set; }
        public string observacao { get; set; }
        public int status { get; set; }
        public decimal valorVenda { get; set; }
        public virtual Categoria categoria { get; set; }
    }
