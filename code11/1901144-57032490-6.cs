    public override void OnReceive(Context context, Intent intent)
    {
        Core.Music music = intent.GetParcelableExtra("selectedMusic") as Core.Music;
        MainActivity.Instance.mTxtSongName.Text = Core.MusicHelper.GetTitleAndAuthor(music.Title);
        MainActivity.Instance.mTxtAuthorName.Text = Core.MusicHelper.GetTitleAndAuthor(music.Author);
        System.Threading.ThreadPool.QueueUserWorkItem(o =>
        {
            string imageUrl = music.Url.Replace(@"\", "").Replace("http", "https");
            var task = Core.MusicHelper.GetSongPic(imageUrl, 35, 35);
            var pic = task.Result;
            if (pic != null)
            {
                MainActivity.Instance.RunOnUiThread(() =>
                {
                    MainActivity.Instance.mImageViewSongPic.SetImageBitmap(pic);
                });
            }
        });
    }
