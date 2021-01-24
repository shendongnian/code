    public class ChangeRingModeService : IChangeRingModeService
    {
        public void changeRingMode()
        {
            AudioManager am = (AudioManager)Application.Context.GetSystemService(Context.AudioService);
            am.RingerMode = RingerMode.Silent;
        }
    }
