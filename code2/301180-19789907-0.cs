     public partial class Age1 : System.Web.UI.Page
        {
            private int Years;
            private int Months;
            private int Days;
            DateTime Cday;
            DateTime Bday;
    
    
            protected void Page_Load(object sender, EventArgs e)
            {
                txtCurrentDate.Enabled = false;
                txtCurrentDate.Text = DateTime.Now.ToString("g");
                Cday = Convert.ToDateTime(txtCurrentDate.Text);
            }
    
            protected void Button1_Click(object sender, EventArgs e)
            {
                Bday = Convert.ToDateTime(txtBirthdate.Text);
                AgeCaluclation(Bday, Cday);
                txtBirthdate.Text = "";
                txtCurrentDate.Text = "";
                lblAge.Text = this.Years+"  Years "+this.Months+"  Months " +this.Days+ "Days";
            }
            
            private Age1 AgeCaluclation(DateTime Bday, DateTime Cday)
            {
               
                if ((Cday.Year - Bday.Year) > 0 || 
                   (((Cday.Year - Bday.Year) == 0) && 
                   ((Bday.Month < Cday.Month) ||
                   ((Bday.Month == Cday.Month) && 
                   (Bday.Day <= Cday.Day)))))
                {
    
                    int DaysInBdayMonth = DateTime.DaysInMonth(Bday.Year, Bday.Month);
                    int DaysRemain = Cday.Day + (DaysInBdayMonth - Bday.Day);
    
                        if(Cday.Month > Bday.Month)
                        {
                            this.Years = Cday.Year - Bday.Year;
                            this.Months = Cday.Month - (Bday.Month + 1) + Math.Abs(DaysRemain / DaysInBdayMonth);
                            this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                        }
                        else if (Cday.Month == Bday.Month)
                        {
                            if (Cday.Day >= Bday.Day)
                            {
                                this.Years = Cday.Year - Bday.Year;
                                this.Months = 0;
                                this.Days = Cday.Day - Bday.Day;
                            }
                            else
                            {
                                this.Years = (Cday.Year - 1) - Bday.Year;
                                this.Months = 11;
                                this.Days = DateTime.DaysInMonth(Bday.Year, Bday.Month) - (Bday.Day - Cday.Day);
    
                            }
                        }
                        else
                        {
                            this.Years = (Cday.Year - 1) - Bday.Year;
                            this.Months = Cday.Month + (11 - Bday.Month) + Math.Abs(DaysRemain / DaysInBdayMonth);
                            this.Days = (DaysRemain % DaysInBdayMonth + DaysInBdayMonth) % DaysInBdayMonth;
                        }
                }
                else
                {
                    throw new ArgumentException("Birthday date must be earlier than current date");
                }
                return this;
            }
        
        }
