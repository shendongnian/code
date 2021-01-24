    public class RecyclerViewHeadHolder : RecyclerView.ViewHolder
    {
        public TextView mDate;
        public RecyclerViewHeadHolder(View itemView) : base(itemView)
        {
            mDate = itemView.FindViewById<TextView>(Resource.Id.mDate);
       
      
        }
   
    }
