        public class SomeModel
        {
            private SomeEnum _MyChoice { get; set; }
            public string MyChoice
            {
                get { return _MyChoice.ToString(); }
                set { _MyChoice = (SomeEnum)Enum.Parse(_MyChoice.GetType(), value); }
            }
        }
        public enum SomeEnum
        {
            OptionOne, OptionTwo, OptionThree
        }
