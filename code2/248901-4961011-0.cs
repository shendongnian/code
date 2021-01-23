    public static void InserirTipoMetadata( TA_TIPO_METADATA tipoMetadata ) {
                using ( EnterpriseContext context = new EnterpriseContext() ) {
                    List<TA_REGRA_VALID> regras = new List<TA_REGRA_VALID>();
                    foreach ( var v in tipoMetadata.TA_REGRA_VALID ) {
                        regras.Add(context.Regra.Single(p => p.CO_SEQ_REGRA == v.CO_SEQ_REGRA));
                    }
                    tipoMetadata.TA_REGRA_VALID = regras;
                    context.TipoMetadata.AddObject(tipoMetadata);
                    context.SaveChanges(System.Data.Objects.SaveOptions.DetectChangesBeforeSave);
                }
            }
