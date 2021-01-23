        void EventInput_CharEntered(object sender, CharacterEventArgs e)
        {
            if (char.IsControl(e.Character))
            {
                switch (e.Character)
                {
                    case '\b':
                        if (hiScoreName.Length > 0)
                        {
                            hiScoreName = hiScoreName.Substring(0, hiScoreName.Length - 1);
                        }
                        break;
                    case '\r':
                        //enter
                        break;
                }
            }
            else
            {
                hiScoreName += e.Character;
            }
        }
