                empleador.OwnsOne(
                property => property.RepresentanteLegal,
                configuration =>
                {
                    configuration.Property(repLegal => repLegal.Nombre).HasColumnName("Nombre").HasMaxLength(500);
                    configuration.OwnsOne(
                        property => property.Rut,
                        rutConfiguracion =>
                        {
                            rutConfiguracion.Property(rut => rut.DigitoVerificador).HasColumnName("RepLegalRutDv");
                            rutConfiguracion.Property(rut => rut.Numero).HasColumnName("RepLegalRutNumero");
                        });
                });
