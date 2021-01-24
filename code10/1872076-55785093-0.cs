        public class ActiveModule
        {
            public long ActiveModuleID { get; set; }
            [ForeignKey("Module")]
            public long BaseModuleID { get; set; }
            public BaseModule Module { get; set; }
        }
        public class BaseModule
        {
            public long BaseModuleID { get; set; }
            public bool CanConfigure { get; set; }
            public bool CanOpen { get; set; }
            public string ModuleName { get; set; }
        }
