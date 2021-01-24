    internal static void BtnOnOff(Button button1, byte v){
     if (v==1)
     {
     button1.Background= System.Windows.Media.Brushes.YellowGreen;
     }
     else
     {
     button1.Background= System.Windows.SystemColors.ControlBrush;
     }
    }
