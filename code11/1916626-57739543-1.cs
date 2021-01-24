    [Route("bot/[controller]")]
    [ApiController]
    public class UpdatesController : ControllerBase {
        private readonly IBot _bot;
        private readonly IUpdatesRouter _updateRoute;
        public UpdatesController(IBot bot, IUpdatesRouter updateRoute) {
            _bot = bot;
            _updateRoute = updateRoute;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update) {
            if (_updateRoute.IsText(update)) {
                await _bot.HandleTextCommandAsync(update.Message);
            }
            return Ok();
        }
    }
