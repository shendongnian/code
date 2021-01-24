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
            mEmails.Add(new Email() { date = "9/25/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/25/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/25/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/24/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/24/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/24/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/23/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
            mEmails.Add(new Email() { date = "9/19/2019", Subject = "Wanna Hang Out?", Message = "I ' ll   be around  tomorrow!!" });
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
            List<DateNow> dateNow = new List<DateNow>();
            List<DateYesterday> dateYesterday = new List<DateYesterday>();
            mItems = new List<ListItem>();
            foreach (var email in mEmails)
            {
                if (!dateList.Contains(email.date))
                {
                    dateList.Add(email.date);
                    dateNow.Add(new DateNow() { dateNow = email.date });
                    dateYesterday.Add(new DateYesterday() { dateYesterday = email.date });
                }
            }
            DateTime today = DateTime.Today;
            string sub = today.ToString().Substring(0, 9);
            int yesterday = Convert.ToInt32(today.Day.ToString()) - 1;
            string ontem = today.Month.ToString() + "/" + yesterday.ToString() + "/" + today.Year.ToString() ;
            foreach (var date in dateNow)
            {
                if (date.dateNow.Equals(sub))
                {
                    mItems.Add(date);
                    foreach (var email in mEmails)
                    {
                        if (email.date.Equals(sub))
                        {
                            mItems.Add(email);
                        }
                    }
                }
                else if (date.dateNow.Equals(ontem))
                {
                    foreach (var DateYesterday in dateYesterday)
                    {
                        if (DateYesterday.dateYesterday.Equals(ontem))
                        {
                            mItems.Add(DateYesterday);
                            foreach (var email in mEmails)
                            {
                                if (email.date.Equals(ontem))
                                {
                                    mItems.Add(email);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (var email in mEmails)
                    {
                        if (!email.date.Equals(sub) && !email.date.Equals(ontem))
                        {
                            mItems.Add(email);
                        }
                            
                    }
                }
                
            }
        }
