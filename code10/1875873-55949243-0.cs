    public class ListOfUpdateMethods
    {
        public delegate void Metodo();
        private List<Metodo> MetodosPreAtualizacao;
        private List<Metodo> MetodosAtualizacao;
    
        public ListOfUpdateMethods()
        {
            this.MetodosPreAtualizacao = new List<Metodo>();
            this.MetodosAtualizacao = new List<Metodo>();
        }
    
        public void AddMetodosPreAtualizacao(Metodo m)
        {
            this.MetodosPreAtualizacao.Add(m);
        }
    
        public void AddMetodosAtualizacao(Metodo m)
        {
           // change this code.
           // this.MetodosPreAtualizacao.Add(m);
           this.MetodosAtualizacao.Add(m);
        }
    
        public void ExecutaMetodosPreAtualizacao()
        {
            foreach (var m in this.MetodosPreAtualizacao)
                m();
        }
    
        public void ExecutaMetodosAtualizacao()
        {
            foreach (var m in this.MetodosAtualizacao)
                m();
        }
    }
