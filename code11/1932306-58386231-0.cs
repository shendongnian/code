    void View.IOnClickListener.OnClick(View v)
    {
        int position = (int)v.Tag;
        listPosition = (int)v.Tag;
        ((Email)mEmails[position]).setSelected(!((Email)mEmails[position]).IsSelected());
        v.SetBackgroundColor(((Email)mEmails[position]).IsSelected() ? Color.LightBlue : Color.Transparent);
        Toast.MakeText(v.Context, "Click : " + ((Email)mEmails[position]).date + "---" + position, ToastLength.Short).Show();
    }
    public void DeleteItem()
    {
        if (mEmails != null && mEmails.Count > 0)
            {
                foreach (Email email in mEmails.ToList())
                {
                    if (email.IsSelected())
                    {
                        mEmails.Remove(email);
                    }
                }
                NotifyDataSetChanged();
            }
    }
