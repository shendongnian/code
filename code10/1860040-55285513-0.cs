    // global variable
    var running = false;    
    
    btn.Click += delegate
                {
    
                if (!running){
                    running = true;
        
                    if (ckb1.Checked)
                    {
                        Items.Add("Regretful");
                    }
                    if (ckb2.Checked)
                    {
                        Items.Add("Empathic");
                    }
                    if (ckb3.Checked)
                    {
                        Items.Add("Shocked");
                    }
                    if (ckb4.Checked)
                    {
                        Items.Add("Shy");
                    }
                    if (ckb5.Checked)
                    {
                        Items.Add("Irritated");
                    }
                    if (ckb6.Checked)
                    {
                        Items.Add("Lazy");
                    }
        
        
                    string result = string.Join(",", Items.ToArray());
        
                    var intent = new Intent(this, typeof(PercentageActivity));
                    StartActivity(intent);
                    intent.PutExtra("EmOmood", result);
                    String eventType = "Medium";
                    intent.PutExtra("mood", eventType);
                    running = false;
                }
        
        
                };
        c# xamarin.android
        shareeditflag
