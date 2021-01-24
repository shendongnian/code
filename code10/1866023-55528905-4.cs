         static public Label label2 = new Label(); // creates ur label (u can name it label1 if u want)
         public Form2()
        {
            Controls.Add(label2); //im not sure where to place it (see above in the load function is best i know)
            Form1.label2.Text = "hi";
            InitializeComponent();
        }
