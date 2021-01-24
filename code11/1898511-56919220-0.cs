        public enum Buttons
        {
            BLUE,
            GREEN,
            YELLOW
        }
        void PickRandomButton()
        {
            int rnd = Random.Range(0, button.Length);
            AnimateAndSavePickedButton((Buttons)rnd);
            ButtonOrder.Add(rnd);
        }
        void AnimateAndSavePickedButton(Buttons button)
        {
            switch (button)
            {
                case Buttons.BLUE:
                    button[0].PressButton();
                    //here your activation event for the blue light
                    break;
                case Buttons.GREEN:
                    button[1].PressButton();
                    //here your activation event for the green light
                    break;
                case Buttons.YELLOW:
                    button[2].PressButton();
                    //here your activation event for the yellow light
                    break;
            }
        }
