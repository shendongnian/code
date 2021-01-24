            List<decimal> nums = new List<decimal>();
            for (int i = 0; i < textBox1.Lines.Count(); ++i)
            {
                string[] line = textBox1.Lines[i].Split(new char[] { ' ' },
                                                        StringSplitOptions.RemoveEmptyEntries);
                foreach (string s in line)
                {
                    nums.Add(decimal.Parse(s, NumberStyles.Number, new CultureInfo("tr-TR")));
                }
            }
            foreach (decimal d in nums.OrderByDescending(x => x))
            {
                listBox1.Items.Add(d.ToString());
            }
