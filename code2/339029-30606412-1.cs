        public bool TestIfWages(string wages)
                {
                    Regex regex = new Regex(@"^\d+\.?\d?\d?$");
                    bool y = regex.IsMatch(wages);
                    return y;
                }
