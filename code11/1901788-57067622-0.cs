    private void DeletMessage(Context context)
        {
            try
            {
                Uri uriSms = Uri.Parse("content://sms/inbox");
                var cursor = context.ContentResolver.Query(uriSms, new string[] { "_id", "thread_id" },
                        null, null, null);
                if (null != cursor && cursor.MoveToFirst())
                {
                    do
                    {
                        // Delete SMS
                        long threadId = cursor.GetLong(1);
                        
                        int result = context.ContentResolver.Delete(Uri
                                .Parse("content://sms/conversations/" + threadId),
                                null, null);
                    } while (cursor.MoveToNext());
                }
            }
            catch (Exception e)
            {
            }
        }
     private void MarkAsRead(Context context)
        {
            Uri uri = Uri.Parse("content://sms/inbox");
            var cursor = context.ContentResolver.Query(uri, null, null, null, null);
            try
            {
                while (cursor.MoveToNext())
                {
                    if ((cursor.GetString(cursor.GetColumnIndex("address")).Equals(number)) && (cursor.GetInt(cursor.GetColumnIndex("read")) == 0))
                    {
                        if (cursor.GetString(cursor.GetColumnIndex("body")).StartsWith(body))
                        {
                            string threadId = cursor.GetString(cursor.GetColumnIndex("_id"));
                            ContentValues values = new ContentValues();
                            values.Put("read", 1);
                            context.ContentResolver.Update(Uri.Parse("content://sms/inbox"), values, "_id=" + threadId, null);
                            return;
                        }
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
