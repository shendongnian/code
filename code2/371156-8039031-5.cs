    public class PlayersController: Controller
    {
        [ChildActionOnly]
        public ActionResult Index()
        {
            var model = new PlayersStatsViewModel();
    
            // TODO: You should absolutely use DI here and replace this hardcoding
            using (var repository = new EFJugadorRepository())
            {
                model.PlayersOnline = repository.FindAllJugadores().Where(j => j.jugEstado == 100).Count();
            }
    
            // TODO: You should absolutely use DI here and replace this hardcoding
            using (var estadisticaMesaRepository = new EFEstadisticaMesaRepository())
            {
                model.TablesInPlay = estadisticaMesaRepository.GetTablesInPlayCount;
                model.AvailableTables = estadisticaMesaRepository.GetAvailableTablesCount;
            }        
    
            return PartialView(model);
        }
    }
