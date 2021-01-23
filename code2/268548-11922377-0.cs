        void wm_WiimoteChanged(object sender, WiimoteChangedEventArgs args)
        {
            WiimoteState ws = args.WiimoteState;
            if (ws.ButtonState.A == true)
            {
                wm.SetRumble(true);
            }
            else
            {
                wm.SetRumble(false);
            }
        }
