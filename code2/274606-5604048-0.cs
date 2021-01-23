     public class Class1
    {
        private enum TheEnum
        {
            stHeader,
            stBody,
            stFooter
        }
        public void SomeMethodEnum()
        {
            TheEnum state = TheEnum.stBody;
            switch (state)
            {
                case TheEnum.stHeader:
                    //do something
                    break;
                case TheEnum.stBody:
                    break;
                case TheEnum.stFooter:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        
        public void SomeMethodConst()
        {
            int state = 1;
            const int Header = 1;
            const int Body = 2;
            const int Footer = 3;
            switch (state)
            {
                case Header:
                    break;
                case Body:
                    break;
                case Footer:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
