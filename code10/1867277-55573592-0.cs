    public class AlunoAcessaArquivo : EntidadeBase {
    
        public virtual Aluno Aluno { get; set; }
    
        public virtual Arquivo Arquivo { get; set; }
    
        public long AlunoId { get; set; } // <-- You missed { get; set; }
        public long ArquivoId { get; set; } // <-- You missed { get; set; }
    }
