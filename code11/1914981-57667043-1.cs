    public class Model
    {
        public ObjectId Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public TokenModel[] Tokens { get; set; }
    }
    public class TokenModel
    {
        public string Token { get; set; }
        public DateTime Geracao { get; set; }
        public DateTime Revogacao { get; set; }
    }
