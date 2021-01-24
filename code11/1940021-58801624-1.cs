    Button button = FindViewById<Button>(Resource.Id.button1);  
    button.Click += delegate {
        Intent intent = new Intent(this, typeof(YOURSECONDACTIVITYHERE));
        startActivity(intent);
    };
    
