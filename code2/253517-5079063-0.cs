    using System;
        using System.Text;
        using System.Windows.Forms;
        using System.Drawing;
    
    class MyForm : Form
    {
        private const int 
            HeightTextBox = 40, WidthTextBox = 25, //размер textboxes
            DistanceBetweenTexBoxHeight = 25, DistanceBetweenTexboxWigth = 25; //растояние между ними
        private int DimentionalTextBox = 3;
        private const int
            RadioButtonNumbers = 3, // количество радио кнопок
            DistanceBetweenRadiobutton = 50,
            RadioButtonFirstGroupStartPositionX = 5,
            RadioButtonSecondGroupStartPositionX = 0,
            RadioButtonFirstGroupStartPositionY = 0,
            RadioButtonSecondGroupStartPositionY = 0,
            RadioButtonSize = 25;
        
        public MyForm()
        {
            //Size of window
            ClientSize = new System.Drawing.Size(7 * HeightTextBox + 8 * DistanceBetweenTexBoxHeight,
                7 * WidthTextBox + 8 * DistanceBetweenTexboxWigth);
    
            //Create RaioButton
            int x = RadioButtonFirstGroupStartPositionX;
            int y;
            RadioButton[] DimRadioButtons = new RadioButton[RadioButtonNumbers];
            for (int i = 0; i < RadioButtonNumbers; i++)
            {
                DimRadioButtons[i] = new RadioButton();
                DimRadioButtons[i].Name = "RadioButton" + (i + 2);
                DimRadioButtons[i].Text = Convert.ToString(i + 2);
                DimRadioButtons[i].SetBounds(x, RadioButtonFirstGroupStartPositionY, RadioButtonSize, RadioButtonSize);
                x += DistanceBetweenRadiobutton;
                Controls.Add(DimRadioButtons[i]);
            }
    
            //Watch dimention
            // And catch even click on RadioButton
            foreach (var a in this.Controls)
            {
                if (a is RadioButton)
                {
                    if (((RadioButton)a).Checked)
                    {
                        DimentionalTextBox = Convert.ToInt16(((RadioButton)a).Text);
                        ((RadioButton)a).Click += new EventHandler(this.TextBoxes);
                    }
                }
            }
        }
    
        // Create-Delete TextBoxes
        private void TextBoxes(object sender, EventArgs e)
        {
            RadioButton rb_click = (RadioButton)sender;
            int x = RadioButtonFirstGroupStartPositionX;
            int y = 30;
            int dim = Convert.ToInt16(rb_click.Text);
            TextBox[,] MatrixTextBoxes = new TextBox[dim, dim];
            for (int i = 0; i < dim; i++)
            {
                for (int j = 0; j < dim; j++)
                {
                    MatrixTextBoxes[i, j] = new TextBox();
                    MatrixTextBoxes[i, j].Top = rb_click.Top;
                    MatrixTextBoxes[i, j].Name = "MatrixTextBox" + i + j;
                    MatrixTextBoxes[i, j].Text = i + " " + j;
                    MatrixTextBoxes[i, j].SetBounds(x, y, WidthTextBox, HeightTextBox);
                    x += DistanceBetweenTexboxWigth;
                    this.Controls.Add(MatrixTextBoxes[i, j]);
                    MatrixTextBoxes[i, j].Show();
                }
                y += DistanceBetweenTexBoxHeight;
                x = RadioButtonFirstGroupStartPositionX;
            }
        }
    }
    
    
    class MyClassMain : MyForm
    {
        public static void Main()
        {
            Application.Run(new MyClassMain());
        }
    }
