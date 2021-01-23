    public class PedidoMap : ClassMap<Pedido>
    {
      PedidoMap()
      {
        Table( "z1_pedido" );
        Id( x => x.Id );
        Map( x => x.Assunto );
        References( x => x.Categoria ).Column( "categoria_id" );
        HasMany( x => x.Interacao ).LazyLoad().Inverse().Cascade.All();
      }
    }
