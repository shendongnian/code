    public enum AgregaClienteStatus
    {
      Success = 0;
      ClientAlreadyExists = 1;
      Other = ??;  // Any other status numbers you want
    }
    
     public AgregaClienteStatus AgregaCliente(_Cliente cliente, ArrayList refes)
     {
           
                Cliente cli = new Cliente()
                {
                    Nombres = cliente.nombres,
                    ApellidoP = cliente.apellidoP,
                    ApellidoM = cliente.apellidoM,
                    FechaNac = cliente.fechaNacimiento
                };
                if (NombreExiste(cli))
                    context.clientes.AddObject(cli);
                else
                    return AgregaClienteStatus.ClientAlreadyExists
                if (refes.Count != 0)
                {
                    foreach (_Referencia elem in refes)
                        context.referencias_personales.AddObject(AgregaReferencia(elem));
                }
                context.SaveChanges();
            
    
            return AgregaClientStatus.Success;
     }
