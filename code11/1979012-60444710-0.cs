                private MainActivity mainActivity;
    
                public BitmapWorkerTask(MainActivity mainActivity)
                {
                    this.mainActivity = mainActivity;
                }
    
                protected override Bitmap RunInBackground(params byte[][] @params)
                {
                    return null;
    
                }
    
                protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] native_parms)
                {
                    base.DoInBackground(native_parms);
                    BitmapFactory.Options options = new BitmapFactory.Options();
                    options.InJustDecodeBounds = false;
                    Thread.Sleep(4000);
                    return BitmapFactory.DecodeByteArray(mainActivity.imageData, 0, mainActivity.imageData.Length, options);
                }
    
                protected override void OnPostExecute(Bitmap result)
                {
                    base.OnPostExecute(result);
                    mainActivity.imageView.SetImageBitmap(result);
                }
            }
