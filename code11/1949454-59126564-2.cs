    DB db = new DB();
    BindingList<Speciality> specialities;
    BindingList<CheckedListBoxItem<Doctor>> doctors;
    private void Form10_Load(object sender, System.EventArgs e)
    {
        specialities = new BindingList<Speciality>(db.Specialities.ToList());
        specialitiesCheckedListBox.DataSource = specialities;
        doctors = new BindingList<CheckedListBoxItem<Doctor>>();
        doctorsCheckedListBox.DataSource = doctors;
        doctors.ListChanged += doctors_ListChanged;
    }
    private void doctors_ListChanged(object sender, ListChangedEventArgs e)
    {
        for (var i = 0; i < doctorsCheckedListBox.Items.Count; i++) {
            doctorsCheckedListBox.SetItemCheckState(i,
                ((CheckedListBoxItem<Doctor>)doctorsCheckedListBox.Items[i]).CheckState);
        }
    }
    private void specialitiesCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        var item = (Speciality)specialitiesCheckedListBox.Items[e.Index];
        if (e.NewValue == CheckState.Checked) {
            db.Doctors.Where(x => x.SpecialityId == item.Id)
                .Select(x => new CheckedListBoxItem<Doctor>(x)).ToList()
                .ForEach(x => doctors.Add(x));
        }
        else {
            doctors.Where(x => x.DataBoundItem.SpecialityId == item.Id)
                .ToList().ForEach(x => doctors.Remove(x));
        }
    }
    private void doctorsCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        ((CheckedListBoxItem<Doctor>)doctorsCheckedListBox.Items[e.Index])
            .CheckState = e.NewValue;
    }
