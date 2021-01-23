    public class CheckMenuIsHealthyJob : QuartzJobObject 
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(CheckMenuIsHealthyJob));
        public IMenuService menuService { get; set; }
        public int HowManyMenuItemsIsOK { get; set; }
        /// <summary>
        /// Check how healthy the menu is by seeing how many menu items are stored in the database. If there
        /// are more than 'HowManyMenuItemsIsOK' then we're ok.
        /// </summary>
        /// <param name="context"></param>
        protected override void ExecuteInternal(JobExecutionContext context)
        {
            IList<MenuItem> items = menuService.GetAllMenuItems();
            if (items != null && items.Count >= HowManyMenuItemsIsOK)
            {
                log.Debug("There are " + items.Count + " menu items. Menu is healthy!");
            }
            else
            {
                log.Warn("Menu needs some menu items adding!");
            }
            
        }
    }
