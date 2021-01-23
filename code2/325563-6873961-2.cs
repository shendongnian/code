    public class TableItemGroup<T> : List<T> where T : TableItem
    {
        public string SectionName { get; set; }
    }
    public abstract class TableItem
    {
        public string TitleLabel { get; set; }
        public string DetailLabel { get; set; }
        public string ImageName { get; set; }
    }
    public class AccountTableItem : TableItem
    {
        public bool SwitchSetting { get; set; }
    }
