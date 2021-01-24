    [BroadcastReceiver]
    public class MusicChangedBroadcastReceiver: BroadcastReceiver
    {
        public MainActivity mainActivity;
        public MusicChangedBroadcastReceiver()
        {
            
        }
        public MusicChangedBroadcastReceiver(MainActivity activity)
        {
            this.mainActivity = activity;
        }
     public override void OnReceive(Context context, Intent intent)
       {
        Core.Music music = intent.GetParcelableExtra("selectedMusic") as Core.Music;
        mMainActivity.mTxtSongName.Text = Core.MusicHelper.GetTitleAndAuthor(music.Title);
        mMainActivity.mTxtAuthorName.Text = Core.MusicHelper.GetTitleAndAuthor(music.Author);
        System.Threading.ThreadPool.QueueUserWorkItem(o =>
        {
            string imageUrl = music.Url.Replace(@"\", "").Replace("http", "https");
            var task = Core.MusicHelper.GetSongPic(imageUrl, 35, 35);
            var pic = task.Result;
            if (pic != null)
            {
                mMainActivity.RunOnUiThread(() =>
                {
                    mMainActivity.mImageViewSongPic.SetImageBitmap(pic);
                });
            }
        });
      }
    }
