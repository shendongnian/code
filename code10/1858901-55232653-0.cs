     button.Click += (sender, e) =>
         {
             tr = new TableRow(this);
             _spinner = new Spinner(this);
             _td1 = new EditText(this);
             _td2 = new EditText(this);
             TextInputLayout textInputLayout1 = new TextInputLayout(this);
             TextInputLayout textInputLayout2 = new TextInputLayout(this);
             _td1.SetHint(Resource.String.qty);
             _td2.SetHint(Resource.String.unit);
            ArrayAdapter<string> _adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, prodList);
            _spinner.Adapter = _adapter;
            textInputLayout1.AddView(_td1);
            textInputLayout2.AddView(_td2);
            tr.AddView(textInputLayout);
            tr.AddView(_spinner);
            tbleLayout.AddView(tr);
        };
