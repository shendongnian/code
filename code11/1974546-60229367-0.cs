       public class DocumentModelDates
        {
            private DateTime _DateStart { get; set; }
            public long DateStart
            {
                get { return _DateStart.ToBinary(); }
                set { _DateStart = DateTime.FromBinary(value);}
            }
        }
