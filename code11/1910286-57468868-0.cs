       public class VolumeKeyClass extends Activity {
        
            void InitializeKeyListener ()
            {
               OnKeyListener keyListener = new OnKeyListener() {
            @Override
            public boolean onKeyUp(int keyCode, KeyEvent event) {
                Log.d("Unity","onKeyUp UP");
                int action = event.getAction();
                switch (keyCode) {
                    case KeyEvent.KEYCODE_VOLUME_UP:
                        if (action == KeyEvent.ACTION_DOWN) {
                            Log.d("test", "Volume UP pressed! " + event);
                     UnityPlayer.UnitySendMessage("MainController","logStatus","Volume up!!");
                        }
                        return true;
                    case KeyEvent.KEYCODE_VOLUME_DOWN:
                        if (action == KeyEvent.ACTION_DOWN) {
                            Log.d("test", "Volume DOWN pressed! " + event);
                            UnityPlayer.UnitySendMessage("MainController","logStatus","Volume Down!");
                        }
                        return true;
                    default:
                        return super.dispatchKeyEvent(event);
                }
               };
            }
        }
