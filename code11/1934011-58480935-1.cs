       if (viewType == ListItem.TYPE_HEADER_DATENOW)
        {// Corresponding subclass: DateNow.cs
            View headNow = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.recyclerviewNow, parent, false);
            RecyclerViewNowHolder view = new RecyclerViewNowHolder(headNow);
            return view;
        }
        else if (viewType == ListItem.TYPE_HEADER_DATEYESTERDAY)
        {// Corresponding subclass: DateYesterday.cs
            View headYesterday = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.recyclerviewYesterday, parent, false);
            RecyclerViewYesterdayHolder view = new RecyclerViewYesterdayHolder(headYesterday);
            return view;
        }
        else if (viewType == ListItem.TYPE_HEADER_BEFORE)
        {// Corresponding subclass: DateBefore.cs
            View headBefore = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.recyclerviewBefore, parent, false);
            RecyclerViewBeforeHolder view = new RecyclerViewBeforeHolder(headBefore);
            return view;
        }
        else
        {//The left is subclass Email.cs
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);
            RecyclerViewHolder view = new RecyclerViewHolder(row);
            return view;
        }
