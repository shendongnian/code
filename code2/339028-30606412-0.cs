                private string wages;
                public string Wages
                {
                    get { return wages; }
                    set
                    {
                        double a = 0;
                        if (!String.IsNullOrWhiteSpace(value))
                        {
                               if (!double.TryParse(value, out a) || 
                               (!TestIfWages(value)))
                               {
                              MessageBox.Show("please enter just the amount; e.g 300.50");
                                }
                         }
                        if (wages != value)
                        {
                        wages = value;
                        }
                    }
                }   
    public bool TestIfWages(string wages)
                {
                    Regex regex = new Regex(@"^\d+\.?\d?\d?$");
                    bool y = regex.IsMatch(year);
                    return y;
                }
