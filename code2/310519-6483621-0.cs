    protected void Page_Load(object sender, EventArgs e)
        {
           if(Session["GeneratedButtons"] == null)
           {
              GenerateButtons generate = new GenerateButtons();
              generate.Generate5Controls(PlaceHolder1);
           }
           else
           {
               List<Control> generatedControls = Session["GeneratedButtons"] as List<Control>;
               foreach(Control oneControl in generatedControls)
               {
                   PlaceHolder1.Controls.Add(oneControl);
               }
           }
        }
    class GenerateButtons
    {
        PlaceHolder placeHolder;
       public  void Generate5Controls(PlaceHolder placeH)
        {
            placeHolder = placeH;
            List<Control> generatedControls = new List<Control>();
            for (int i = 0; i < 5; i++)
            {
                Button newBtn = new Button();
                newBtn.Click += btn_Click;
                newBtn.Text = "PageLoadButton Created. Number: "+i;
                placeHolder.Controls.Add(newBtn);
                AddControlToSession(newBtn);
            }
        }
        public void btn_Click(object sender, EventArgs e)
        {
            Button newBTN = new Button();
            newBTN.Text = "A New Button was added by the button event btn_click";
            newBTN.Click += btn2_Click;
            placeHolder.Controls.Add(newBTN);
            AddControlToSession(newBtn);
        }
    
        public void btn2_Click(object sender, EventArgs e)
        {
            Button newBTN = new Button();
            newBTN.Text = "A New Button was added by the button event btn2_click";
            placeHolder.Controls.Add(newBTN);
            AddControlToSession(newBtn);
        }
    
        private void AddControlToSession(Control ctrl)
        {
            List<Control> generatedControls = Session["GeneratedButtons"] as List<Control>;
            if(generatedControls == null)
            {
                generatedControls = new List<Control>();
            }
            generatedControls.Add(ctrl);
            Session["GeneratedButtons"] = generatedControls;
        }
    }
