    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework.Input;
    namespace CodeName
    {
    public class KbHandler
    {
        private Keys[] lastPressedKeys;
        public string tekst = "";
        public KbHandler()
        {
            lastPressedKeys = new Keys[0];
        }
        public void Update()
        {
            KeyboardState kbState = Keyboard.GetState();
            Keys[] pressedKeys = kbState.GetPressedKeys();
            //check if any of the previous update's keys are no longer pressed
            foreach (Keys key in lastPressedKeys)
            {
                if (!pressedKeys.Contains(key))
                    OnKeyUp(key);
            }
            //check if the currently pressed keys were already pressed
            foreach (Keys key in pressedKeys)
            {
                if (!lastPressedKeys.Contains(key))
                    OnKeyDown(key);
            }
            //save the currently pressed keys so we can compare on the next update
            lastPressedKeys = pressedKeys;
        }
    //Create your own   
    private void OnKeyDown(Keys key)
        {
            switch (key)
            {
                case Keys.D0:
                    tekst += "0";
                    break;
                case Keys.D1:
                    tekst += "1";
                    break;
                case Keys.D2:
                    tekst += "2";
                    break;
                case Keys.D3:
                    tekst += "3";
                    break;
                case Keys.D4:
                    tekst += "4";
                    break;
                case Keys.D5:
                    tekst += "5";
                    break;
                case Keys.D6:
                    tekst += "6";
                    break;
                case Keys.D7:
                    tekst += "7";
                    break;
                case Keys.D8:
                    tekst += "8";
                    break;
                case Keys.D9:
                    tekst += "9";
                    break;
                case Keys.NumPad0:
                    tekst += "0";
                    break;
                case Keys.NumPad1:
                    tekst += "1";
                    break;
                case Keys.NumPad2:
                    tekst += "2";
                    break;
                case Keys.NumPad3:
                    tekst += "3";
                    break;
                case Keys.NumPad4:
                    tekst += "4";
                    break;
                case Keys.NumPad5:
                    tekst += "5";
                    break;
                case Keys.NumPad6:
                    tekst += "6";
                    break;
                case Keys.NumPad7:
                    tekst += "7";
                    break;
                case Keys.NumPad8:
                    tekst += "8";
                    break;
                case Keys.NumPad9:
                    tekst += "9";
                    break;
                case Keys.OemPeriod:
                    tekst += ".";
                    break;
                case Keys.Back:
                    if (tekst.Length > 0)
                    {
                        tekst = tekst.Remove(tekst.Length - 1, 1);
                    }                    
                    break;
              
            }
        }
        private void OnKeyUp(Keys key)
        {
            //do stuff
        }
    }
    }
