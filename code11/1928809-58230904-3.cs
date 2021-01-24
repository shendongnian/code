     public void DeleteItem(int position)
        {
            if (mEmails!=null && mEmails.Count>0) {
               mEmails.RemoveAt(position);
               NotifyDataSetChanged();
              NotifyItemChanged(listPosition);
            }
        }
