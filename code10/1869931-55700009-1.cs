          //1.inflate the Customlayout
            View content = LayoutInflater.Inflate(Resource.Layout.Customlayout, null);
            //2. Getting the view elements
            TextView textView = (TextView)content.FindViewById(Resource.Id.dialog_content);
            TextView alertTitle = (TextView)content.FindViewById(Resource.Id.dialog_title);
            Button button1 = (Button)content.FindViewById(Resource.Id.dialog_btn_cancel);
            Button button2 = (Button)content.FindViewById(Resource.Id.dialog_btn_sure);
            //3. Setting font
            textView.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
            alertTitle.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
            button1.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
            button2.SetTypeface(Typeface.Serif, TypefaceStyle.BoldItalic);
            //4.create a new alertDialog
            Android.App.AlertDialog alertDialog = new Android.App.AlertDialog.Builder(this).Create();
       
            //5. set the view
            alertDialog.SetView(content);
            
            //6. show the dialog
            alertDialog.Show(); // This should be called before looking up for elements
