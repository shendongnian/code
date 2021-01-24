        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder myHolder = holder as RecyclerViewHolder;
            myHolder.mName.Text = mEmails[position].Name;
            myHolder.mSubject.Text = mEmails[position].Subject;
            myHolder.mMessage.Text = mEmails[position].Message;
            myHolder.ItemView.Click += (sender, e) =>
              {
                  selectionposition = position;
                  NotifyDataSetChanged();
              };
        }
