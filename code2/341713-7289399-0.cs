    public class MyColleagueCollection : ObservableCollection<MyColleague>
    {
       public MyColleagueCollection()
       {
           Add(new MyColleague() { Name = "Tim", Surname = "Meier" });
           Add(new MyColleague() { Name = "Martin", Surname = "Hansen" });
           Add(new MyColleague() { Name = "Oliver", Surname = "Drumm" });
       }
    }
