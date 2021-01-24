    public class PessoaContatoModel
    {
        public int FormaContatoId { get; set; }
        public string FormaContatoDescricao { get; set; }
        public string Contato { get; set; }
        public string Observacao { get; set; }
        public bool ContatoPrincipal { get; set; }
    }
    [HttpPost]
    [Route("pessoa-gerenciar/changeFormaContato")]
    public IActionResult ChangeFormaContato([FromBody] PessoaContatoModel pessoaContatoViewModel)
