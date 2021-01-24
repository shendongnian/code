    using CheetNET.Core;
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    public class Cheet : Cheet<System.Windows.Forms.Keys>
    {
        private static readonly Regex LetterKeysNamePattern = new Regex(@"^[a-z]$");
        private static readonly Regex NumberKeysNamePattern = new Regex(@"^[0-9]$");
        private static readonly Regex KeyspadNumberKeysNamePattern = new Regex(@"^kp_[0-9]$");
        private static readonly Regex FunctionKeysNamePattern = new Regex(@"^(?:f[1-9]|f1[0-2])$");
    
        private PreviewKeyDownEventArgs lastHandledEvent;
    
        public virtual void OnKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e == lastHandledEvent)
            {
                return;
            }
            OnKeyDown(e.KeyCode);
            lastHandledEvent = e;
        }
    
        protected override Keys GetKey(string KeysName)
        {
            if (LetterKeysNamePattern.IsMatch(KeysName))
            {
                return ParseKey(KeysName.ToUpper());
            }
            if (NumberKeysNamePattern.IsMatch(KeysName))
            {
                return ParseKey("D" + KeysName);
            }
            if (KeyspadNumberKeysNamePattern.IsMatch(KeysName))
            {
                return ParseKey(KeysName.Replace("kp_", "NumPad"));
            }
            if (FunctionKeysNamePattern.IsMatch(KeysName))
            {
                return ParseKey(KeysName.ToUpper());
            }
            switch (KeysName)
            {
                case "left":
                case "L":
                case "←":
                    return Keys.Left;
                case "up":
                case "U":
                case "↑":
                    return Keys.Up;
                case "right":
                case "R":
                case "→":
                    return Keys.Right;
                case "down":
                case "D":
                case "↓":
                    return Keys.Down;
                case "backspace":
                    return Keys.Back;
                case "tab":
                    return Keys.Tab;
                case "enter":
                    return Keys.Enter;
                case "return":
                    return Keys.Return;
                case "shift":
                case "⇧":
                    return Keys.LShiftKey;
                case "control":
                case "ctrl":
                case "^":
                    return Keys.LControlKey;
                case "alt":
                case "option":
                case "⌥":
                    return Keys.Alt;
                case "command":
                case "⌘":
                    return Keys.LWin;
                case "pause":
                    return Keys.Pause;
                case "capslock":
                    return Keys.CapsLock;
                case "esc":
                    return Keys.Escape;
                case "space":
                    return Keys.Space;
                case "pageup":
                    return Keys.PageUp;
                case "pagedown":
                    return Keys.PageDown;
                case "end":
                    return Keys.End;
                case "home":
                    return Keys.Home;
                case "insert":
                    return Keys.Insert;
                case "delete":
                    return Keys.Delete;
                case "equal":
                case "=":
                    return Keys.Oemplus;
                case "comma":
                case ",":
                    return Keys.Oemcomma;
                case "minus":
                case "-":
                    return Keys.OemMinus;
                case "period":
                case ".":
                    return Keys.OemPeriod;
                case "kp_multiply":
                    return Keys.Multiply;
                case "kp_plus":
                    return Keys.Add;
                case "kp_minus":
                    return Keys.Subtract;
                case "kp_decimal":
                    return Keys.Decimal;
                case "kp_divide":
                    return Keys.Divide;
            }
            throw new ArgumentException(String.Format("Could not map Keys named '{0}'.", KeysName));
        }
    
        private static Keys ParseKey(string KeysName)
        {
            return (Keys)Enum.Parse(typeof(Keys), KeysName);
        }
    }
