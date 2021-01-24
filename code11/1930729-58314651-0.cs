    private void CalculateButton_Click(object sender, EventArgs e)
            {
                double gpa = 0;
                List<double> grades = new List<double>();
    
                foreach (Control textBox in Controls)
                {
                    if ((textBox.GetType().ToString() == "System.Windows.Forms.TextBox") && (textBox.Name.Contains("gradeBox")))
                    {
                        grades.Add(double.Parse(textBox.Text));
                    }
                }
    
                for (int i = 0; i < grades.Count; i++)
                {
                    gpa += grades[i];
                }
                gpa /= grades.Count;
    
                gpaBox.Text = gpa.ToString();
            }
