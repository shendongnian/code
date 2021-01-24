        public static async void CustomAnimation(double position, AbsoluteLayout name)
        {
            for (double i = 0; i < 81; i++)
            {
                 Change here how you want to change the opacity(can make custom animation)
                var x = 1 - 0.0125 * i;
                if (position == i)
                {
                    await name.FadeTo(x, 30, Easing.SinOut);
                }
            }
        }
