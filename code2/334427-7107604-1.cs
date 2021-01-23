    public class Data1List : ObservableCollection<Data1>
    {
        public Data1List()
        {
            Add(new Data1{ Id = 1, Dep = ".NET", Sal = 5000, JoinDate = "04/08/2011"});
            Add(new Data1{ Id = 2, Dep = ".NET", Sal = 6000, JoinDate = "04/07/2011"});
            Add(new Data1{ Id = 3, Dep = "JAVA", Sal = 7000, JoinDate = "04/08/2011"});
            Add(new Data1{ Id = 4, Dep = "JAVA", Sal = 8000, JoinDate = "04/07/2011"});
            Add(new Data1{ Id = 5, Dep = ".NET", Sal = 9000, JoinDate = "04/06/2011"});
        }
    }
    public class Data2List : ObservableCollection<Data2>
    {
    }
