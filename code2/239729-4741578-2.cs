    interface IPerson
        {
            ICollection<string> NickNames{get;set;}
        }
    
    public class ObservablePerson : IPerson
        {
            ICollection<string> nickNames = new ObservableCollection<string>();
    
            ICollection<string> IPerson.NickNames
            {
                get
                {
                    return nickNames;
                }
                set
                {
                    nickNames = value;
                }
            }
        }
        public class ListPerson : IPerson
        {
            ICollection<string> nickNames = new List<string>();
    
            ICollection<string> IPerson.NickNames
            {
                get
                {
                    return nickNames;
                }
                set
                {
                    nickNames = value;
                }
            }
        }
