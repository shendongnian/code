    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            const int ROWS = 3;
            const int COLS = 3;
            const int WIDTH = 100;
            const int HEIGHT = 100;
            const int SPACE = 20;
            static TextBox[,] gameBoard;
            public Form1()
            {
                InitializeComponent();
                gameBoard = new TextBox[ROWS, COLS];
                for (int row = 0; row < ROWS; row++)
                {
                    for (int col = 0; col < COLS; col++)
                    {
                        TextBox newTextBox = new TextBox();
                        newTextBox.Multiline = true;
                        this.Controls.Add(newTextBox);
                        newTextBox.Height = HEIGHT;
                        newTextBox.Width = WIDTH;
                        newTextBox.Top = SPACE + (row * (HEIGHT + SPACE));
                        newTextBox.Left = SPACE + (col * (WIDTH + SPACE));
                        gameBoard[row, col] = newTextBox;
                    }
                }
            }
        }
    }
