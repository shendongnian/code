    class MySettings : PropertyChangedNotifier
    {
     public string UserName
     {
      get{return mUserName;}
      set{mUserName=value; RaisePropertyChanged("UserName");}
     }
    }
