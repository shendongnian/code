    class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<ListItem>  mEmails;
        public RecyclerAdapter(List<ListItem> mEmails, Context context)
        {
            this.mEmails = mEmails;
     
        }
        public override int ItemCount
        {
            get { return mEmails.Count; }
        }
        public override int GetItemViewType(int position)
        {
            return mEmails[position].getType();
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            int type = GetItemViewType(position);
            if (type == ListItem.TYPE_HEADER)
            {
                RecyclerViewHeadHolder myHolder = holder as RecyclerViewHeadHolder;
                myHolder.mDate.Text = ((DataItem)mEmails[position]).Date;
       
            }
            else
            {
                RecyclerViewHolder myHolder = holder as RecyclerViewHolder;
                myHolder.mName.Text = ((Email)mEmails[position]).date;
                myHolder.mSubject.Text = ((Email)mEmails[position]).Subject;
                myHolder.mMessage.Text = ((Email)mEmails[position]).Message;
            }      
        }
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            if (viewType == ListItem.TYPE_HEADER)
            {
                View head = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.head, parent, false);
                RecyclerViewHeadHolder view = new RecyclerViewHeadHolder(head);
                return view;
            }
            else
            {
                View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);
                RecyclerViewHolder view = new RecyclerViewHolder(row);
                return view;
            }       
        }
    } 
