    int i = 0;
            public void ChangeClassButton()
            {
                while (!changeClassBool)
                {
                    Debug.Log(activeDrum[i]);
                    changeClassText.text = activeDrum[i];
                    OscMessage oscM = Osc.StringToOscMessage("/changeClass" + i);
                    Debug.Log(Osc.OscMessageToString(oscM));
                    oscHandler.Send(oscM);
                    changeClassBool = true;
                    if (i >= activeDrum.Length)
                    {
                        i = 0;
                    }
                    else
                    {
                        ++i;
                    }
                }
            }
