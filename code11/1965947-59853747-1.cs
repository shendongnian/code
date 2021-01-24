    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        ViewHolder holder = null;
        var view = convertView;
        if (view == null) {
            view = context.LayoutInflater.Inflate(Resource.Layout.userlayout, parent, false);
            var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
            var deleteUser = view.FindViewById<ImageView>(Resource.Id.userDelete);
            var addUser = view.FindViewById<ImageView>(Resource.Id.userAdd);
            holder = new ViewHolder() { Name = name, btnDelete = deleteUser, btnAdd = addUser };
            view.Tag = holder; 
            holder.btnDelete.Click += (sender, args) =>
            {
              int btnPosition = (int)((Button)sender).Tag;
              AlertDialog.Builder dialog = new AlertDialog.Builder(context);
              AlertDialog alert = dialog.Create();
              alert.SetTitle("Delete");
              alert.SetMessage("Are you sure you want to delete this user");
              alert.SetButton("OK", (c, ev) =>
              {
                Toast.MakeText(context, "You going to delete " + holder.id + " " + users[btnPosition].FirstName + " " + users[btnPosition].LastName, ToastLength.Long).Show();
                alert.Dismiss();
                alert.Hide();
              });
              alert.SetCancelable(true);
              alert.Show();
             };
         }
         holder = (ViewHolder)view.Tag;
         holder.btnDelete.Tag = position;
         holder.id = users[position].Id;
         holder.Name.Text = users[position].LastName;
         return view;
    }
