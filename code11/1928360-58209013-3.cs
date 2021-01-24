    public class RecyclerAdapter : RecyclerView.Adapter
    {
        private List<Email> mEmails;
        private Activity mActivity;
    
        public RecyclerAdapter(List<Email> emails, Activity activity)
        {
            mEmails = emails;
            mActivity = activity;
        }
    
        public override int ItemCount => mEmails.Count;
    
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View row = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.row, parent, false);
            RecyclerViewHolder view = new RecyclerViewHolder(row);
            return view;
        }
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder myHolder = holder as RecyclerViewHolder;
            myHolder.mDate.Text = ((Email)mEmails[position]).date;
            myHolder.mSubject.Text = ((Email)mEmails[position]).Subject;
            myHolder.mMessage.Text = ((Email)mEmails[position]).Message;
        }
    
        public void RemoveItem(int position)
        {
            //Pass mActivity here as an argument instead of the context field like you did before:
            Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(mActivity);
            AlertDialog alert = dialog.Create();
            alert.SetTitle("Atenion");
            alert.SetMessage("About to delete a row permanently, do you want to proceed ?");
            alert.SetButton("OK", (c, ev) =>
            {
                mEmails.RemoveAt(position);
                NotifyDataSetChanged();
                NotifyItemChanged(position);
            });
            alert.SetButton2("CANCEL", (c, ev) => { });
            alert.Show();
        }
    }
