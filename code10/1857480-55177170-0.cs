    private void Form1_Load(object sender, EventArgs e)
            {
                for (int i = 0; i < 100; i++)
                {
                    Label label = new Label();
                    label.AutoSize = false;
                    label.Width = 50;
                    label.Text = i.ToString();
                    flowLayoutPanel1.Controls.Add(label);
                }
                DataPresenter presenter = new DataPresenter(this);
                presenter.CalculateArea();
            }
