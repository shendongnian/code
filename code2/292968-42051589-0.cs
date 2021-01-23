    update your ObservableCollectionmembers too
    Eg: 
    
    private ObservableCollection<Member> memberCollection;
            public ObservableCollection<Member> MemberCollection
            {
                get { return memberCollection; }
                set { memberCollection = value;
                    OnPropertyChanged();
                }
            }
    
    public void SaveMember()
            {
                try
                {
                    _bussiness.Update(SelectedMember);
                    MemberCollection.Add(SelectedMember);
                    ShowMessageBox(this, new MessageEventArgs()
                    {
                        Message = "Changes are saved !"
                    });
                }
                catch (Exception ex)
                {
                    ShowMessageBox(this, new MessageEventArgs()
                    {
                        Message = ex.Message
                    });
                }
            }
