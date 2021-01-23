    public class CargoMapping : ClassMap<Cargo>
    {
        public CargoMapping()
        {
            this.Id(x => x.Id);
            this.Map(x => x.Nome);
            this.Map(x => x.Descricao);
            this.Map(x => x.IsActive);
            this.References(x => x.Area);
        }
    }
