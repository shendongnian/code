    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            //***********************
            Photo item =   mPhotoAlbum[position];
            //***********************
            //vh.MyCheckBox.Tag = position;
            vh.Caption.Text = item.Caption;
            vh.MyCheckBox.SetOnCheckedChangeListener(null);
            vh.MyCheckBox.SetOnCheckedChangeListener(new MyListener(item));
            vh.MyCheckBox.Checked = item.isChecked;
        }
