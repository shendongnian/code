public class FuncionarioPagante
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FuncionarioPaganteId { get; set; }
    public int PessoaId { get; set; }
    [ForeignKey("PessoaId")]
    public virtual Pessoa Pessoa { get; set; }
    public int? EmpresaId { get; set; }
    [ForeignKey("EmpresaId")]
    public virtual Empresa Empresa { get; set; }
}
