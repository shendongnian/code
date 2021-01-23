      public class NonTabStopRadioButton : RadioButton
      {
          protected override void OnTabStopChanged(EventArgs e)
          {
              base.OnTabStopChanged(e);
              if (TabStop)
                TabStop = false;
          }
      }
