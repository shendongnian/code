    private List<Email> mEmails;
    private List<ListItem> mItems;
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        Xamarin.Essentials.Platform.Init(this, bundle);
        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);
        mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerViwer);
        mRecyclerView.AddItemDecoration(new DividerItemDecoration(mRecyclerView.Context, DividerItemDecoration.Vertical));
        mRecyclerView.HasFixedSize = true;
        SetupList();
        //Create our layout Manager
        mLayoutManager = new LinearLayoutManager(this);
        mRecyclerView.SetLayoutManager(mLayoutManager);
        RecyclerAdapter mAdapter = new RecyclerAdapter(mItems, this);
        mRecyclerView.SetAdapter(mAdapter);
    }
     
    private void SetupList()
        {
            mEmails = new List<Email>();
            mEmails.Add(new Email() { date = "9/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "8/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "8/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "7/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "7/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "6/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "6/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "5/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "5/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "4/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "4/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/19/2018", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/19/2018", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            List<string> dateList = new List<string>();
            List<DataItem> dateItems = new List<DataItem>();
            mItems = new List<ListItem>();
            foreach (var email in mEmails)
            {
                if (!dateList.Contains(email.date))
                {
                    dateList.Add(email.date);
                    dateItems.Add(new DataItem() { Date = email.date});
                   
                }
             
            }
            foreach (var date in dateItems)
            {
                mItems.Add(date);
 
                foreach (var email in mEmails)
                {
                    if (date.Date.Equals(email.date))
                    {
                        mItems.Add(email);
                    }
           
                }
            }  
        }
