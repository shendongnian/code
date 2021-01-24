    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace downloadstatuspage
    {
        public partial class dowloadstatuspage : Form
        {
            const int WIDTH = 100;
            const int HEIGHT = 100;
            const int SPACE = 10;
            const int TOP = 10;
            public dowloadstatuspage()
            {
                InitializeComponent();
                string[] buttonNames = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" };
                List<Button> pizzaButtons = new List<Button>();
                int size = (int)Math.Sqrt(buttonNames.Length);
                if (size * size != buttonNames.Length) size++; 
                int buttonCount = 0;
                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (buttonCount == buttonNames.Length) break;
                        
                        Button pizzaControlButton = new Button();
                        pizzaButtons.Add(pizzaControlButton);
                        this.Controls.Add(pizzaControlButton);
                        pizzaControlButton.Top = TOP + row * ( SPACE + HEIGHT);
                        pizzaControlButton.Left = col * (SPACE + WIDTH);
                        pizzaControlButton.Width = WIDTH;
                        pizzaControlButton.Height = HEIGHT;
                        pizzaControlButton.Text = buttonNames[buttonCount];
                        pizzaControlButton.Name = buttonNames[buttonCount];
                        pizzaControlButton.ForeColor = Color.White;
                        pizzaControlButton.BackColor = Color.Navy;
                        buttonCount++;
                    }
                    if (buttonCount == buttonNames.Length) break;
                }
            }
        }
    }
