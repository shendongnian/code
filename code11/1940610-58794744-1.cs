    class MyListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
        {
            Photo photo;
            public MyListener( Photo item)
            {
                this.photo = item;
            }
            public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
            {
                photo.isChecked = isChecked;
            }
        }
