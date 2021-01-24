    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    namespace Project
    {
        public enum UsableKeys
        {
            A = Keys.A,
            B = Keys.B,
            C = Keys.C,
            D = Keys.D,
        }
        public partial class Form1 : Form
        {
            Dictionary<UsableKeys, int?> shortcutDictionary = new Dictionary<UsableKeys, int?>();
            public Form1()
            {
                InitializeComponent();
                foreach (UsableKeys key in Enum.GetValues(typeof(UsableKeys)))
                {
                    // You may add default shortcut here
                    this.shortcutDictionary.Add(key, null);
                }
            }
            private void Form1_KeyDown(object sender, KeyEventArgs e)
            {
                UsableKeys keyPressed = (UsableKeys)e.KeyCode;
                if (this.shortcutDictionary.ContainsKey(keyPressed))
                {
                    executeAction(keyPressed);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.L)
                {
                    switch (this.shortcutDictionary[UsableKeys.A])
                    {
                        case 1:
                            this.shortcutDictionary[UsableKeys.A] = 4;
                            this.shortcutDictionary[UsableKeys.B] = 3;
                            this.shortcutDictionary[UsableKeys.C] = 2;
                            this.shortcutDictionary[UsableKeys.D] = 1;
                            break;
                        case null:
                            this.shortcutDictionary[UsableKeys.A] = 1;
                            this.shortcutDictionary[UsableKeys.B] = 2;
                            this.shortcutDictionary[UsableKeys.C] = 3;
                            this.shortcutDictionary[UsableKeys.D] = 4;
                            break;
                        case 4:
                            this.shortcutDictionary[UsableKeys.A] = null;
                            this.shortcutDictionary[UsableKeys.B] = null;
                            this.shortcutDictionary[UsableKeys.C] = null;
                            this.shortcutDictionary[UsableKeys.D] = null;
                            break;
                    }
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            private void executeAction(UsableKeys keyPressed)
            {
                int? num = null;
                if (this.shortcutDictionary.TryGetValue(keyPressed, out num))
                {
                    switch (num)
                    {
                        case 1:
                            attack();
                            break;
                        case 2:
                            defend();
                            break;
                        case 3:
                            hide();
                            break;
                        case 4:
                            dance();
                            break;
                        default:
                            Console.WriteLine("Key not bounded");
                            break;
                    }
                }
            }
            private void attack()
            {
                Console.WriteLine("Player swing his word");
            }
            private void defend()
            {
                Console.WriteLine("Player raise his shield");
            }
            private void hide()
            {
                Console.WriteLine("Player sneak around");
            }
            private void dance()
            {
                Console.WriteLine("Player start to dance");
            }
        }
    }
