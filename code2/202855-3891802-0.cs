       protected override void OnLoad(EventArgs e)
       {
           Application.OpenForms[0].Activated += new EventHandler(Form2_Activated);
           base.OnLoad(e);
       }
       void Form2_Activated(object sender, EventArgs e)
       {
           Console.WriteLine("Activated!");
       }        
