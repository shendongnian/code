    private void subjectBlock_Tap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      var subject = sender.DataContext Subject;
      if(null != subject) {
        string subjectid = subject.SubjectID;
        NavigationService.Navigate(new Uri("/eIICS;component/Pages/Coursework.xaml?type=2&subject=" + subjectid, UriKind.Relative));
      }
    }
