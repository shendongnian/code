 <uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
 <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
###in your DepdencyService
void GetAllImage()
{
   Android.Net.Uri imageUri = MediaStore.Images.Media.ExternalContentUri;
   var carsor = ContentResolver.Query(imageUri,null, MediaStore.Images.ImageColumns.MimeType + "=? or "+ MediaStore.Images.ImageColumns.MimeType+ "=?",new string[] { "image/jpeg", "image/png" }, MediaStore.Images.ImageColumns.DateModified);
   while(carsor.MoveToNext())
   {
     string path = carsor.GetString(carsor.GetColumnIndex(MediaStore.Images.ImageColumns.Data));
     Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
     streamArray.Add(stream);
   }
}
