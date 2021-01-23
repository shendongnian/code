                using(RENDataContext db = new RENDataContext()){
    
                    Processo update = tabela.SingleOrDefault(
                        x => x.CodTrans == pCodTrans);
    
                    update.SentDate= DateTime.Now;
                    update.ProcessId = pProcessId;
                    update.LogUsuario = pUsuario_Id;
                    update.LogVersaoRegistro = servico.LogVersaoRegistro + 1;
                    update.LogDataAlteracao = DateTime.Now;
    
                    db.SubmitChanges();
                }
