        private void Form1_Load(object sender, EventArgs e)
        {
            MotorPolicy mp = new MotorPolicy();
            mp.Description = "Motor";
            SetForm(mp);       
        }
        private void SetForm(Policy p)
        {
            lblDescription.Text = p.Description;
            lblDetail.Text = p.Details;
            //then if you still need specifics 
            if (p.GetType() == typeof(MotorPolicy))
            {
                MotorPolicy mp = p as MotorPolicy;
                //continue assigning mp
            }
            else if (p.GetType() == typeof(HousePolicy))
            {
                HousePolicy hp = p as HousePolicy;
                //continue assigning Hp
            }
        }
