    private string _userComment;
     
    public string UserComment
    {
       get { return _userComment; }
       set 
       {
          _userComment = value;
          PropertyChanged("UserComment");
       }
    }
     
    private void PropertyChanged(string prop)
    {
       if( PropertyChanged != null )
       {
          PropertyChanged(this, new PropertyChangedEventArgs(prop);
       }
    }
