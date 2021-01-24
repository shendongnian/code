    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.DepartmentPopUpListViewRow, parent, false);
        // var DepartmentpopUp = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.DepartmentPopUpListViewRow, parent, false);
    
        var btnRadio = view.FindViewById<RadioButton>(Resource.Id.SelectedDepartment);
        btnRadio.SetOnCheckedChangeListener(null);
        btnRadio.Tag = position;
        btnRadio.Checked = Departments[position].Checked;
        btnRadio.SetOnCheckedChangeListener(this);
    
        view.FindViewById<TextView>(Resource.Id.SelectDepartmentName).Text = Departments[position].Afdeling_Txt;
        return view;
    }
    public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
    {
        int position = (int)buttonView.Tag;
        if (isChecked)
        {
            foreach (DepartmentDto model in Departments)
            {
                if (model != Departments[position])
                {
                    model.Checked = false;
                }
                else
                {
                    model.Checked = true;
                }
            }
            NotifyDataSetChanged();
        }
    }
