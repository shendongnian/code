    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = holder as StaffViewHolder;
            vh.Layout.SetBackgroundColor(position % 2 == 0 ? Color.ParseColor("#ffffff") : Color.ParseColor("#f5f5f5"));
            vh.Layout.Foreground = vh.ItemView.Context.GetDrawable(Resource.Drawable.ripple_foreground);
            vh.StaffTv.Text = items[position].Name;
        }
