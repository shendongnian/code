c#
  public List<PlanoEvidenciaIForm> ListaPlanoEvidenciaIForm { get; set; }
  public List<IFormFile> Arquivos { get; set; }
  public class PlanoEvidenciaIForm
  {
    public int IdPlanoAcaoEvidencia { get; set; }
    public string Nota { get; set; }
    public DateTime Data { get; set; }
  }
html
    <!-- The IFormFile doesn't use [ ] -->
    <input asp-for="Arquivos" class="form-control" type="file" />
    <input asp-for="ListaPlanoEvidenciaIForm[0].Nota" class="form-control" />
