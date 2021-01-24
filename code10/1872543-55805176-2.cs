     btnSelectImage = (Button)FindViewById(Resource.Id.btnSelectImage);
            Bitmap bitmap = BitmapFactory.DecodeResource(this.ApplicationContext.Resources , Resource.Drawable.splashlogo);
            btnSelectImage.Click += (o, e) =>
            {
                saveImageToGally(bitmap, this);
            };
