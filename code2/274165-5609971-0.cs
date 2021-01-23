            dontShowPANEL();
            //ActiveForm.Close();
            MainImaginCp kj = new MainImaginCp();
           //kj.Visible = false;
            kj.panel2.Controls.Clear();
            panel1.Visible = true;
            EngABCLearning usr1 = new EngABCLearning();
            usr1.Show();
            kj.panel2.Controls.Add(usr1); 
            //kj.Focus();
        }**
