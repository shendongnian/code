    public class DokumentHandlowyCFactory
    {
        public DokumentHandlowyC Create(Guid id)
        {
            using (var session = new eaContext().Login.CreateSession(true, false))
            {
                var HM = HandelModule.GetInstance(session);
                dokumentHandlowy = null;
                try
                {
                    dokumentHandlowy = HM.DokHandlowe[id];
                }
                catch (Exception)
                {
                    var message = 
                      $"DokumentHandlowy o Guid: '{id}'{System.Environment.NewLine}nie istnieje.";
                    throw new Enova_BrakWskazanegoObiektu(message);
                }
                return DokumentHandlowyC(dokumentHandlowy);
            }
        }
    }
